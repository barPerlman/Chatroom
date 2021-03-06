﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Sort
{
     public class SortbyNickname : ISort
    {
        /// <summary>
        /// specifies whether the sorting is ascending or descending.
        /// </summary>
        private bool _ascending;
         public SortbyNickname(bool ascending)
        {
            _ascending = ascending;
        }
        public List<Message> DoAction(List<Message> messages)
        {
            string res = "";
            List<Message> sortedMessages;
            if (_ascending)
            {
                var sortedMsg = (from msg in messages             //the following orders the msgList by nickname
                               orderby msg.nickname ascending
                               select msg);
                sortedMessages = sortedMsg.ToList();
                foreach (Message msg in sortedMsg)                //convert the msgList content to a returned string
                    res += msg + "\n";
            }
            else
            {
                var sortedMsg = (from msg in messages             //the following orders the msgList by nickname
                               orderby msg.nickname descending
                               select msg).Take(int.MaxValue);
                sortedMessages = sortedMsg.ToList();
                foreach (Message msg in sortedMsg)                //convert the msgList content to a returned string
                    res += msg + "\n";
            }
            return sortedMessages;
        }
    }
}
