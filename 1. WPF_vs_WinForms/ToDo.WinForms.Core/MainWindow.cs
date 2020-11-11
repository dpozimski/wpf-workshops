using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo.WinForms.Core
{
    public partial class MainWindow : Form
    {
        private List<ToDoItemModel> _todoItems = new List<ToDoItemModel>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btAddTask_Click(object sender, EventArgs e)
        {
            var text = tbTask.Text;

            var id = _todoItems.Select(ti => ti.Id).LastOrDefault() + 1;
            var model = new ToDoItemModel() { Id = id, Task = text };

            _todoItems.Add(model);
            UpdateLeftCounter();
            UpdateListBoxSource(_todoItems);
        }

        private void btAll_Click(object sender, EventArgs e)
        {
            UpdateListBoxSource(_todoItems);
        }

        private void btActive_Click(object sender, EventArgs e)
        {
            UpdateListBoxSource(_todoItems.Where(ti => !ti.Done));
        }

        private void btCompleted_Click(object sender, EventArgs e)
        {
            UpdateListBoxSource(_todoItems.Where(ti => ti.Done));
        }

        private void UpdateLeftCounter()
        {
            tbLeftCounter.Text = $"{_todoItems.Count(m => !m.Done)} items left";
        }

        private void UpdateListBoxSource(IEnumerable<ToDoItemModel> todoItems)
        {
            lbToDoItems.Items.Clear();

            foreach(var model in todoItems)
            {
                lbToDoItems.Items.Add(model, model.Done);
            }

            lbToDoItems.DisplayMember = nameof(ToDoItemModel.Task);
            lbToDoItems.ValueMember = nameof(ToDoItemModel.Done);
        }

        private void lbToDoItems_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var dataSource = (sender as CheckedListBox).Items;
            var model = dataSource[e.Index] as ToDoItemModel;
            model.Done = e.NewValue == CheckState.Checked;
            UpdateLeftCounter();
        }
    }
}
