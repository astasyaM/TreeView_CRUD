using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeView_CRUD
{
    public class TreeNodeID: TreeNode
    {
        public int ID {  get; set; }
        public int NodeLevel { get; set; }

        public TreeNodeID(string text, int id, int level): base(text)
        {
            ID = id;
            NodeLevel = level;
        }
    }
}
