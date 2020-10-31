using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repo
{
    public class Badges_Repo
    {
        private List<Badge> _badgeContent = new List<Badge>();

        public Dictionary<int, List<string>> MakeDictionaryOfBadges()
        {
            Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
            foreach (Badge content in _badgeContent)
            {
                _badgeDictionary.Add(content.BadgeID, content.Access);
            }
            return _badgeDictionary;
        }

        public bool AddBadge(Badge content)
        {
            int startingCount = _badgeContent.Count;

            _badgeContent.Add(content);

            bool wasAdded = (_badgeContent.Count > startingCount) ? true : false;

            return wasAdded;
        }
        public Badge GetContentByBadgeID(int badgeID)
        {
            foreach (Badge content in _badgeContent)
            {
                if (content.BadgeID == badgeID)
                {
                    return content;
                }
            }
            return null;
        }
        public bool UpdateBadge(int oldBadgeID, Badge newContent)
        {
            Badge oldContent = GetContentByBadgeID(oldBadgeID);

            if (oldContent != null)
            {
                oldContent.BadgeID = newContent.BadgeID;
                oldContent.Access = newContent.Access;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
