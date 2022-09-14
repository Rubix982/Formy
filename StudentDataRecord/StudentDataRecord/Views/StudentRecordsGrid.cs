using StudentDataRecord.StudentDataRecord.Models.Repositories;

namespace StudentDataRecord.StudentDataRecord.Views
{
    public partial class StudentRecordsGrid : Form
    {
        private readonly StudentForm _studentForm;
        private readonly StudentRepository _studentRepository;

        public StudentRecordsGrid(StudentForm studentForm)
        {
            InitializeDataGridView();

            // If all parameters in C# are passed by value then why does the below work?
            // I think no new object is instantiated, because, if you do a "prev" on the
            // first form, you still get the state before you pressed "next"
            _studentForm = studentForm;
            _studentRepository =
                StudentRepository.GetStudentRepositoryInstance(StudentRepository.GetPropertyList(), null, null);
        }

        private static void GenerateSuccessMessageBox(string? text, string? caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void PreviousButton_Click(object sender, EventArgs e)
        {
            Hide();
            _studentForm.Show();
        }

        private void InitializeDataGridView()
        {
            InitializeComponent();

            // Pattern thanks to
            // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview?view=netframework-4.8
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }


        private void SetupLayout()
        {

        }

        private void SetupDataGridView()
        {

        }

        public void PopulateDataGridView()
        {
            StudentDataGridView.Rows.Clear();

            var students = StudentRepository.Instance!.GetAll();
            if (students!.Count == 0)
            {
                StudentDataGridView.RowCount = 1;
            }
            else
            {
                StudentDataGridView.RowCount = students!.Count;

                for (var iterator = 0; iterator < students!.Count; iterator++)
                {
                    StudentDataGridView.Rows[iterator].Cells[0].Value = students[iterator].Id;
                    StudentDataGridView.Rows[iterator].Cells[1].Value = students[iterator].Name;
                    StudentDataGridView.Rows[iterator].Cells[2].Value = students[iterator].Address;
                    StudentDataGridView.Rows[iterator].Cells[3].Value = students[iterator].Phone;
                    StudentDataGridView.Rows[iterator].Cells[4].Value = students[iterator].Email;
                    StudentDataGridView.Rows[iterator].Cells[5].Value = students[iterator].Course;
                    StudentDataGridView.Rows[iterator].Cells[6].Value = students[iterator].Year;
                    StudentDataGridView.Rows[iterator].Cells[7].Value = students[iterator].Age;
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (StudentDataGridView.SelectedRows.Count <= 0 ||
                StudentDataGridView.SelectedRows[0].Index ==
                StudentDataGridView.Rows.Count - 1) return;

            var index = StudentDataGridView.SelectedRows[0].Index;

            StudentDataGridView.Rows.RemoveAt(index);
            StudentRepository.Instance!.DeleteByIndex(index);
        }

        private void SaveToExcelButton_Click(object sender, EventArgs e)
        {
            _studentRepository.WriteToExcel();
            GenerateSuccessMessageBox("Written To Excel Successfully", "Excel: Write Successful");
        }
    }
}
