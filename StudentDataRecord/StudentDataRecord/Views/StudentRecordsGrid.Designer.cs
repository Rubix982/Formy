namespace StudentDataRecord.StudentDataRecord.Views
{
    partial class StudentRecordsGrid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NextButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.StudentDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentGroupBox = new System.Windows.Forms.GroupBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SaveToExcelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StudentDataGridView)).BeginInit();
            this.StudentGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // NextButton
            // 
            this.NextButton.AccessibleDescription = "Go to the next form";
            this.NextButton.AccessibleName = "NextButton";
            this.NextButton.Enabled = false;
            this.NextButton.Location = new System.Drawing.Point(665, 392);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(94, 29);
            this.NextButton.TabIndex = 20;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            // 
            // PreviousButton
            // 
            this.PreviousButton.AccessibleDescription = "Go to the previous option";
            this.PreviousButton.AccessibleName = "PrevButton";
            this.PreviousButton.Location = new System.Drawing.Point(545, 392);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(94, 29);
            this.PreviousButton.TabIndex = 19;
            this.PreviousButton.Text = "Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // StudentDataGridView
            // 
            this.StudentDataGridView.AccessibleName = "StudentDataGridView";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            this.StudentDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.StudentDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StudentDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.StudentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.FullName,
            this.Address,
            this.Phone,
            this.Email,
            this.Course,
            this.Year,
            this.Age});
            this.StudentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentDataGridView.Location = new System.Drawing.Point(3, 23);
            this.StudentDataGridView.Name = "StudentDataGridView";
            this.StudentDataGridView.RowHeadersWidth = 51;
            this.StudentDataGridView.RowTemplate.Height = 29;
            this.StudentDataGridView.Size = new System.Drawing.Size(1110, 348);
            this.StudentDataGridView.TabIndex = 21;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.Frozen = true;
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Width = 51;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "Name";
            this.FullName.Frozen = true;
            this.FullName.HeaderText = "Name";
            this.FullName.MinimumWidth = 6;
            this.FullName.Name = "FullName";
            this.FullName.Width = 78;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.Frozen = true;
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.Width = 91;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Phone";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            this.Phone.Width = 79;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.Width = 75;
            // 
            // Course
            // 
            this.Course.DataPropertyName = "Course";
            this.Course.HeaderText = "Course";
            this.Course.MinimumWidth = 6;
            this.Course.Name = "Course";
            this.Course.Width = 83;
            // 
            // Year
            // 
            this.Year.DataPropertyName = "Year";
            this.Year.HeaderText = "Year";
            this.Year.MinimumWidth = 6;
            this.Year.Name = "Year";
            this.Year.Width = 66;
            // 
            // Age
            // 
            this.Age.DataPropertyName = "Age";
            this.Age.HeaderText = "Age";
            this.Age.MinimumWidth = 6;
            this.Age.Name = "Age";
            this.Age.Width = 65;
            // 
            // StudentGroupBox
            // 
            this.StudentGroupBox.Controls.Add(this.StudentDataGridView);
            this.StudentGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.StudentGroupBox.Location = new System.Drawing.Point(0, 0);
            this.StudentGroupBox.Name = "StudentGroupBox";
            this.StudentGroupBox.Size = new System.Drawing.Size(1116, 374);
            this.StudentGroupBox.TabIndex = 22;
            this.StudentGroupBox.TabStop = false;
            this.StudentGroupBox.Text = "Students";
            // 
            // DeleteButton
            // 
            this.DeleteButton.AccessibleName = "DeleteButton";
            this.DeleteButton.Location = new System.Drawing.Point(12, 392);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(149, 29);
            this.DeleteButton.TabIndex = 23;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SaveToExcelButton
            // 
            this.SaveToExcelButton.AccessibleName = "SaveToExcelButton";
            this.SaveToExcelButton.Location = new System.Drawing.Point(12, 427);
            this.SaveToExcelButton.Name = "SaveToExcelButton";
            this.SaveToExcelButton.Size = new System.Drawing.Size(149, 29);
            this.SaveToExcelButton.TabIndex = 24;
            this.SaveToExcelButton.Text = "Save To Excel";
            this.SaveToExcelButton.UseVisualStyleBackColor = true;
            this.SaveToExcelButton.Click += new System.EventHandler(this.SaveToExcelButton_Click);
            // 
            // StudentRecordsGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 490);
            this.Controls.Add(this.SaveToExcelButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.StudentGroupBox);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Name = "StudentRecordsGrid";
            this.Text = "StudentRecordsGrid";
            ((System.ComponentModel.ISupportInitialize)(this.StudentDataGridView)).EndInit();
            this.StudentGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Button NextButton;
        private Button PreviousButton;
        private DataGridView StudentDataGridView;
        private GroupBox StudentGroupBox;
        private Button DeleteButton;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn Phone;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Course;
        private DataGridViewTextBoxColumn Year;
        private DataGridViewTextBoxColumn Age;
        private Button SaveToExcelButton;
    }
}