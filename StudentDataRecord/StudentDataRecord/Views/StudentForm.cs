using System.ComponentModel;
using StudentDataRecord.StudentDataRecord.Models.Entities;
using StudentDataRecord.StudentDataRecord.Models.Repositories;

namespace StudentDataRecord.StudentDataRecord.Views
{
    public partial class StudentForm : Form
    {
        private StudentRecordsGrid? _studentRecordsGrid;
        private bool _hasValidInputBeenPassed;
        private readonly StudentRepository _studentRepository;
        
        public StudentForm()
        {
            InitializeComponent();
            _studentRecordsGrid = null;
            _hasValidInputBeenPassed = true;
            _studentRepository = StudentRepository.GetStudentRepositoryInstance(StudentRepository.GetPropertyList(), null, null);
        }

        private static void GenerateSuccessMessageBox(string? text, string? caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GenerateErrorMessageBox(string? text, string? caption)
        {
            _hasValidInputBeenPassed = false;

            var result = MessageBox.Show(text, caption, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            if (result == DialogResult.Cancel)
            {
                Dispose();
            }
        }

        private bool SaveButtonValidation()
        {
            const string genericCaption = "Error: Empty field!";

            if (NameTextBox.Text == "")
            {
                GenerateErrorMessageBox(@"Name was empty!", genericCaption);
            }
            else if (AddressTextBox.Text == "")
            {
                GenerateErrorMessageBox(@"Address was empty!", genericCaption);
            }
            else if (PhoneTextBox.Text == "")
            {
                GenerateErrorMessageBox(@"Phone was empty!", genericCaption);
            }
            else if (EmailTextBox.Text == "")
            {
                GenerateErrorMessageBox(@"Email was empty!", genericCaption);
            }
            else if (CourseComboBox.Text == "")
            {
                GenerateErrorMessageBox(@"Course was empty!", genericCaption);
            }
            else if (YearComboBox.Text == "")
            {
               GenerateErrorMessageBox(@"Year was empty!", genericCaption); 
            }
            else if (AgeTextBox.Text == "")
            {
                GenerateErrorMessageBox(@"Age was empty!", genericCaption);
            }
            else
            {
                _hasValidInputBeenPassed = true;
            }

            return _hasValidInputBeenPassed;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            Hide();
            _studentRecordsGrid ??= new StudentRecordsGrid(this);
            _studentRecordsGrid.PopulateDataGridView();
            _studentRecordsGrid.Show();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!SaveButtonValidation()) return;

            var student = new Student("", NameTextBox.Text, AddressTextBox.Text, PhoneTextBox.Text,
                EmailTextBox.Text, CourseComboBox.Text, YearComboBox.Text, AgeTextBox.Text);
            _studentRepository.Add(student);

            GenerateSuccessMessageBox(@"Student successfully added!", "Success: Student Added");
        }

        private void StudentForm_Close(object sender, EventArgs? eventArgs)
        {
            // TODO: Why isn't the below debug line working?
            // Console.WriteLine(@"Hello, World! From Close");
            
            // Is actually the cancel object
            var cancelEventArgs = (eventArgs as CancelEventArgs);
            if (DialogResult != DialogResult.Cancel) return;

            // Assume that X has been clicked and act accordingly
            // Confirm user wants to close
            if (cancelEventArgs != null)
                cancelEventArgs.Cancel = MessageBox.Show(this, @"Are you sure?",
                        @"Do you still want enter details of more students?", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) switch
                    {
                        DialogResult.No => true,
                        _ => cancelEventArgs.Cancel
                    };
        }
    }
}
