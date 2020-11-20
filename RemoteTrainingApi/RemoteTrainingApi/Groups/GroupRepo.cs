using Microsoft.EntityFrameworkCore;
using RemoteTrainingApi.Groups.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemoteTrainingApi.Groups
{
    public class GroupRepo : IGroupRepo
    {
        private readonly RTADbContext _db;

        public GroupRepo(RTADbContext db) {
            _db = db;
        }

        public async Task<List<Group>> GetGroups()
        {
            return await _db.Group.ToListAsync();
        }

        public async Task<GroupGet> GetGroup(int groupId, int userId)
        {
            var group = await _db.Group.FirstOrDefaultAsync(o => o.GroupId == groupId);
            var membership = await _db.Membership.FirstOrDefaultAsync(o => o.GroupId == groupId && o.UserId == userId);

            bool? joined = membership == null ? null : (bool?)(membership.Role > 0);

            return new GroupGet()
            {
                GroupId = group.GroupId,
                Name = group.Name,
                Joined = joined,
                IsPublic = group.IsPublic
            };
        }

        public async Task<bool> PostGroup(GroupPost groupPost, int userId)
        {
            Group group = new Group()
            {
                Name = groupPost.Name,
                IsPublic = groupPost.IsPublic,
            };

            using (_db)
            {
                await _db.Group.AddAsync(group);
                await _db.SaveChangesAsync();

                int groupId = group.GroupId;

                await _db.Membership.AddAsync(
                    new Membership()
                    {
                        UserId = userId,
                        GroupId = groupId,
                        Role = 2
                    }
                );
                await _db.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> JoinGroup(int groupId, int userId)
        {
            var group = await _db.Group.FirstOrDefaultAsync(o => o.GroupId == groupId);
            await _db.AddAsync(
                new Membership()
                {
                    UserId = userId,
                    GroupId = groupId,
                    Role = group.IsPublic ? 1 : 0
                }
            );
            await _db.SaveChangesAsync();
            return true;
        }
    }

    public interface IGroupRepo
    {
        Task<List<Group>> GetGroups();
        Task<GroupGet> GetGroup(int groupId, int userId);
        Task<bool> JoinGroup(int groupId, int userId);
        Task<bool> PostGroup(GroupPost groupPost, int userId);
    }
}
