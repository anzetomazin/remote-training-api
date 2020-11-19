using Microsoft.EntityFrameworkCore;
using RemoteTrainingApi.Workouts.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RemoteTrainingApi.Workouts
{
    public class WorkoutRepo : IWorkoutRepo
    {
        private readonly RTADbContext _db; 

        public WorkoutRepo(RTADbContext db)
        {
            _db = db;
        }

        public async Task<bool> PostExerciseToWorkout(int workoutId, int exerciseId, int userId)
        {
            Workout workout = await _db.Workout.FirstOrDefaultAsync(o => o.WorkoutId == workoutId && o.UserId == userId);
            Exercise exercise = await _db.Exercise.FirstOrDefaultAsync(o => o.ExerciseId == exerciseId);

            ExerciseOnWorkout eow = new ExerciseOnWorkout()
            {
                WorkoutId = workout.WorkoutId,
                ExerciseId = exercise.ExerciseId
            };

            await _db.ExerciseOnWorkout.AddAsync(eow);
            int result = await _db.SaveChangesAsync();
            return result == 1;
        }

        public async Task<Workout> PostWorkout(WorkoutPost workoutPost, int userId)
        {
            Workout workout = new Workout()
            {
                Name = workoutPost.Name,
                UserId = userId,
                IsTemplate = workoutPost.IsTemplate
            };

            using (_db)
            {
                await _db.Workout.AddAsync(workout);
                int result = await _db.SaveChangesAsync();

                int id = workout.WorkoutId; // Yes it's here
                return await _db.Workout.FirstOrDefaultAsync(o => o.WorkoutId == id);
            }
        }

        public async Task<List<Exercise>> GetExercises()
        {
            return await _db.Exercise.Where(o => o.ExerciseId < 1000).ToListAsync();
        }
        
        public async Task<List<ExerciseSet>> GetExerciseOnWorkoutSets(int exerciseOnWorkoutId)
        {
            return await _db.ExerciseSet.Where(o => o.ExerciseOnWorkoutId == exerciseOnWorkoutId).ToListAsync();
        }

        public async Task<bool> PostExercise(ExercisePost exercisePost, int userId)
        {

            Exercise exercise = new Exercise()
            {
                Name = exercisePost.Name,
                UserId = userId
            };

            await _db.Exercise.AddAsync(exercise);
            int result = await _db.SaveChangesAsync();
            return result == 1;
        }

        public async Task<List<ExerciseOnWorkoutGet>> GetExercisesOnWorkout(int workoutId)
        {
            var eows = await _db.ExerciseOnWorkout.Where(o => o.WorkoutId == workoutId).Include(c => c.Exercise).ToListAsync();
            List<ExerciseOnWorkoutGet> list = new List<ExerciseOnWorkoutGet>();
            foreach(var eow in eows)
            {
                list.Add(
                    new ExerciseOnWorkoutGet()
                    {
                        ExerciseOnWorkoutId = eow.ExerciseOnWorkoutId,
                        ExerciseName = eow.Exercise.Name == null ? "Odstranjena vaja" : eow.Exercise.Name
                    }
                );
            }
            return list;
        }

        public async Task<bool> DeleteExerciseOnWorkout(int exerciseOnWorkoutId, int userId)
        {
            var res = await _db.ExerciseOnWorkout.Include(c => c.Workout).FirstOrDefaultAsync(o => o.Workout.UserId == userId && o.ExerciseOnWorkoutId == exerciseOnWorkoutId);
            var eow = res;
            _db.Remove(eow);
            int result = await _db.SaveChangesAsync();
            return result == 1;
        }

        public async Task<bool> PostExerciseSetToExercise(int exerciseOnworkoutId, int userId)
        {
            var eow = await _db.ExerciseOnWorkout.Include(c => c.Workout).FirstOrDefaultAsync(o => o.ExerciseOnWorkoutId == exerciseOnworkoutId && o.Workout.UserId == userId);
            ExerciseSet set = new ExerciseSet()
            {
                DurationSeconds = 0,
                ExerciseOnWorkoutId = eow.ExerciseOnWorkoutId,
                IsCompleted = false,
                PauseSeconds = 0,
                Repetitions = 0,
                Weight = 0
            };

            await _db.ExerciseSet.AddAsync(set);
            int result = await _db.SaveChangesAsync();
            return result == 1;
        }

        public async Task<bool> DeleteWorkout(int workoutId)
        {
            Workout workout = await _db.Workout.FirstOrDefaultAsync(o => o.WorkoutId == workoutId);
            _db.Remove(workout);
            int result = await _db.SaveChangesAsync();
            return result == 1;
        }

        public async Task<bool> PutWorkout(WorkoutPut workoutPut)
        {
            var workout = await _db.Workout.FirstOrDefaultAsync(o => o.WorkoutId == workoutPut.WorkoutId);

            workout.Name = workoutPut.Name;
            workout.IsTemplate = workoutPut.IsTemplate;

            var result = await _db.SaveChangesAsync();

            return result == 1;
        }

        public async Task<List<Workout>> GetWorkouts(int userId)
        {
            return await _db.Workout.Where(o => o.UserId == userId && !o.IsTemplate).ToListAsync();
        }

    }

    public interface IWorkoutRepo
    {
        Task<Workout> PostWorkout(WorkoutPost workoutPost, int userId);
        Task<bool> PostExerciseToWorkout(int workoutId, int exerciseId, int userId);
        Task<List<ExerciseOnWorkoutGet>> GetExercisesOnWorkout(int workoutId);
        Task<List<Exercise>> GetExercises();
        Task<bool> PostExercise(ExercisePost exercisePost, int userId);
        Task<bool> DeleteExerciseOnWorkout(int exerciseOnWorkoutId, int userId);
        Task<bool> PostExerciseSetToExercise(int exerciseOnworkoutId, int userId);
        Task<List<ExerciseSet>> GetExerciseOnWorkoutSets(int exerciseOnWorkoutId);
        Task<bool> DeleteWorkout(int workoutId);
        Task<bool> PutWorkout(WorkoutPut workoutPut);
        Task<List<Workout>> GetWorkouts(int workoutId);
    }
}
