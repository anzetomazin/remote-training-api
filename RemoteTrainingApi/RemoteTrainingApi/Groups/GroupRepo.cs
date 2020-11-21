using Microsoft.EntityFrameworkCore;
using RemoteTrainingApi.Groups.Models;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> PutGroup(GroupPost groupPost, int groupId, int userId)
        {
            var membership = await _db.Membership.FirstOrDefaultAsync(o => o.UserId == userId && o.GroupId == groupId);
            if (membership != null && membership.Role == 2)
            {
                var group = await _db.Group.FirstOrDefaultAsync(o => o.GroupId == groupId);
                group.Name = groupPost.Name;
                group.IsPublic = groupPost.IsPublic;

                await _db.SaveChangesAsync();

                return true;
            }

            return false;
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

        public async Task<List<MembershipGet>> GetMemberships(int groupId, int userId)
        {
            var memberships = await _db.Membership.Where(o => o.GroupId == groupId).ToListAsync();
            var membershipsGet = new List<MembershipGet>();

            foreach(Membership membership in memberships)
            {
                var user = await _db.User.Where(o => o.UserId == membership.UserId).FirstOrDefaultAsync();
                membershipsGet.Add(
                    new MembershipGet()
                    {
                        MembershipId = membership.MembershipId,
                        MemberName = user.FirstName + " " + user.LastName,
                        Role = membership.Role
                    }
                );
            }

            return membershipsGet;
        }

        public async Task<bool> PutMembership(int membershipId, int role, int userId)
        {
            var membership = await _db.Membership.FirstOrDefaultAsync(o => o.MembershipId == membershipId);
            var userMembership = await _db.Membership.FirstOrDefaultAsync(o => o.UserId == userId && o.GroupId == membership.GroupId);


            int[] validRoles = { 1, -1, 2 };

            if (userMembership.Role > 1 && validRoles.Contains(role))
            {
                membership.Role = role;
                await _db.SaveChangesAsync();
            }

            return true;
        }

        public async Task<List<Group>> GetJoinedGroups(int userId)
        {
            var memberships = await _db.Membership.Where(o => o.UserId == userId && o.Role > 0).ToListAsync();
            List<Group> groups = new List<Group>();

            foreach(var membership in memberships)
            {
                groups.Add(await _db.Group.FirstOrDefaultAsync(o => o.GroupId == membership.GroupId));
            }

            return groups;
        }
    }

    public interface IGroupRepo
    {
        Task<List<Group>> GetGroups();
        Task<GroupGet> GetGroup(int groupId, int userId);
        Task<bool> JoinGroup(int groupId, int userId);
        Task<bool> PostGroup(GroupPost groupPost, int userId);
        Task<bool> PutGroup(GroupPost groupPost, int groupId, int userId);
        Task<List<MembershipGet>> GetMemberships(int groupId, int userId);
        Task<bool> PutMembership(int membershipId, int role, int userId);
        Task<List<Group>> GetJoinedGroups(int userId);
    }
}
