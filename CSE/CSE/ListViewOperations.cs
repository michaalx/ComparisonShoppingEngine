using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSE
{
    class ListViewOperations
    {
        public void CopySelectedItems(ListView source, ListView target)
        {
            foreach (ListViewItem item in source.SelectedItems)
            {
                target.Items.Add((ListViewItem)item.Clone());
            }
        }

        public void RemoveSelectedItems(ListView listViewCart)
        {
            for(int i = 0; i < listViewCart.Items.Count; i ++)
            {
                if (listViewCart.Items[i].Selected)
                {
                    listViewCart.Items[i].Remove();
                }
            }
        }
    }
}
