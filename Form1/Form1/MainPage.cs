using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeBehind;
using System.Collections;
using System.Data.Entity;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;

namespace Form1
{
	public partial class MainPage : Form
	{
		int index;
		StringBuilder blocksList=  new StringBuilder();
		List<int> session = new List<int>()
		{
			2017, 2018, 2019, 2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027, 2028,
			2029, 2030, 2031, 2032, 2033, 2034, 2035
		};
		bool flag = true, dateflag = false;
		DateTimePicker dtp = new DateTimePicker();
		Rectangle _rect;
		private _context _con;
		public MainPage(string name)
		{
			InitializeComponent();
			lbl_name.Text = name;
			_con = new _context();            
			dataGridView1.Controls.Add(dtp);
			dtp.Visible = false;
			dtp.Format = DateTimePickerFormat.Custom;
			dtp.Value = DateTime.Now;
			dtp.TextChanged += new EventHandler(txt_TextChanged);
			dataGridView1.CellClick += dataGridView1_CellClick;
			dataGridView1.Columns[3].DefaultCellStyle.NullValue = "Save";
			dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.White;
			dataGridView1.Columns[3].DefaultCellStyle.ForeColor = Color.Tomato;
		}

		//public MainPage(string name)
		//{
		//    InitializeComponent();
		//    lbl_name.Text = name;
		//    _con = new _context();
		//}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
			Form1 obj = new Form1();
			obj.Show();
		}

		private void MainPage_Load(object sender, EventArgs e)
		{
			deptAdd();
			typeAdd();
			AddSession();
			oddComboBox.Items.Add("ODD");
			oddComboBox.Items.Add("EVEN");
		}

		public void AddSession()
		{
			foreach (var data in session)
			{
				SessionComboBox.Items.Add(data);
			}
		}

		public void deptAdd()
		{
			var data = _con.Departments.ToList();
			foreach (var dept in data)
			{
				box_dept.Items.Add(dept.name);
			}
		}

		public void AddCourse()
		{
			var q = box_dept.SelectedItem.ToString();
			var data = _con.Courses.Include(c => c.department).ToList();
			foreach (var query in data)
			{
				if (query.department.name == q)
				{
					box_course.Items.Add(query.name);
				}
			}
		}
		public void AddShift()
		{
			shiftSelect.Items.Clear();
			var data = _con.Shift.ToList();
			foreach (var query in data)
			{
				shiftSelect.Items.Add(query.shift);
			}
		}


		public void AddSubject()
		{
			AddShift();
			var data = _con.Subject.Where(c => c.course.name.Contains(box_course.SelectedItem.ToString()) && (c.Type.name.Equals(box_type.SelectedItem.ToString())) && c.semester.name.Contains(box_semester.SelectedItem.ToString()));
			int count = 0;
			foreach (var query in data)
			{

				dataGridView1.Rows.Add();
				dataGridView1.Rows[count].Cells[0].Value = query.name;
				count++;
			}
		}

		public void typeAdd()
		{
			var data = _con.Type.ToList();
			foreach (var type in data)
				box_type.Items.Add(type.name);
		}

		public void semesterAdd()
		{
			var q = box_course.SelectedItem.ToString();
			var data = _con.Courses.SingleOrDefault(c => c.name == q);
			var no = data.total_number_of_Semester;
			var sem = _con.Semester.ToList();
			for (int i = 1; i <= no; i++)
			{
				foreach (var semester in sem)
				{
					if (semester.id == i)
						box_semester.Items.Add(semester.name);
				}
			}
		}

		//Add Course to box at run time
		private void box_dept_SelectedIndexChanged(object sender, EventArgs e)
		{
			box_course.Items.Clear();
			box_semester.Items.Clear();
			AddCourse();
		}

		//Add Semester to box at run time
		private void box_course_SelectedIndexChanged(object sender, EventArgs e)
		{
			box_semester.Items.Clear();
			semesterAdd();
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			switch (dataGridView1.Columns[e.ColumnIndex].Name)
			{
				case "dateSelect":
					{
						_rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
						dtp.Size = new Size(_rect.Width, _rect.Height);
						dtp.Location = new Point(_rect.X, _rect.Y);
						dtp.Visible = true;
						break;
					}
			}

		}

		private void txt_TextChanged(object sender, EventArgs e)
		{
			//DateTime date = Convert.ToDateTime(dtp.Text);
			//var data = _con.SubjectDateSheet.SingleOrDefault(c => c.date == date);
			if (dtp.Value.DayOfWeek == DayOfWeek.Sunday)
			{
				flag = false;
				MessageBox.Show("Can`t Select Sundays", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			//else if (data != null)
			//{
			//    flag = false;
			//    MessageBox.Show("Can`t Allocate this Date Because its Already Alloted to " + data.subject.name + " " + data.subject.semester.name + " " + data.subject.course.name + " " + data.subject.course.department.name, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			//    shift = data.shift.shift;
			//}
			else
			{
				if (dateflag == false)
				{
					flag = true;
					dataGridView1.CurrentCell.Value = dtp.Text.ToString();
				}
				else if (dateflag == true)
				{
					//MessageBox.Show("Index " + index.ToString());
					//MessageBox.Show("Index +1" + (index +1).ToString());
					flag = true;
					dataGridView1[1, index+1].Value = dtp.Text.ToString();
				}
			}

		}

		private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
		{
			dtp.Visible = false;
		}

		private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
		{
			dtp.Visible = false;
		}

		private void box_semester_SelectedIndexChanged(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear();
			if (box_type.SelectedItem != null && box_semester.SelectedItem != null && box_dept.SelectedItem != null)
			{
				AddSubject();
				panel6.Visible = true;
				blocksList = new StringBuilder();
			}
		}

		private void box_type_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (box_type.SelectedItem != null && box_semester.SelectedItem != null && box_dept.SelectedItem != null)
			{
				AddSubject();
				panel6.Visible = true;
				blocksList = new StringBuilder();
			}
		}


		//Save the data into the database about the datesheet
		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 1)
				index = e.RowIndex;
			var shift1 = shiftSelect.Items.ToString();
			var type = _con.Type.FirstOrDefault(c => c.name.Contains(box_type.SelectedItem.ToString()));
			var course = _con.Courses.FirstOrDefault(c => c.name.Contains(box_course.SelectedItem.ToString()));
			var semester = _con.Semester.FirstOrDefault(c => c.name.Contains(box_semester.SelectedItem.ToString()));
			if (e.ColumnIndex == 3)
			{
				index = e.RowIndex;
				string subjects = dataGridView1[0, e.RowIndex].Value as String;
				string date = dataGridView1[1, e.RowIndex].Value as String;
				string shifts = dataGridView1[2, e.RowIndex].Value as String;
				//string block = dataGridView1[3, e.RowIndex].Value as String;                
				try
				{
					DateTime dt = Convert.ToDateTime(date);
					//MessageBox.Show(dt.ToString());
					var typeId = _con.Type.SingleOrDefault(c => c.name == box_type.SelectedItem.ToString());
					var semesterId = _con.Semester.SingleOrDefault(c => c.name == box_semester.SelectedItem.ToString());
					var courseId = _con.Courses.SingleOrDefault(c => c.name == box_course.SelectedItem.ToString());
					var subjectId = _con.Subject.SingleOrDefault(c => c.name == subjects);
					var sessions = Convert.ToInt32(SessionComboBox.SelectedItem);                    
                    var dateChecker = _con.SubjectDateSheet.Where(c => (c.date == dt) && (c.odd_even == oddComboBox.SelectedItem.ToString()) && (c.session == sessions) && (c.tbl_subjectID == subjectId.id) && (c.datesheet.tbl_courseId == courseId.id) && (c.datesheet.tbl_typeId == typeId.id) && (c.datesheet.tbl_semesterId == semesterId.id)).ToList();
					if (dateChecker != null)
					{
						StringBuilder sb = new StringBuilder();
						foreach (var datecheck in dateChecker)
						{
							var blockId = _con.Block.SingleOrDefault(c => c.id == datecheck.tbl_blockId);
							sb.Append("-> " + date + " already have the exam of " + subjects + " in " + blockId.name + " on " + shifts + "\n");

						}
						String str = "";
						if (!String.IsNullOrEmpty(str = sb.ToString()))
						{
							MessageBox.Show(sb.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
							dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
							dateflag = true;
						}
					}
					if (dateChecker.Count() == 0)
					{
						dateflag = true;
						var shift = _con.Shift.FirstOrDefault(c => c.shift == shifts);
						var subject = _con.Subject.FirstOrDefault(c => c.name == subjects);
						//var blocks = _con.Block.FirstOrDefault(c => c.name == block);
						//var data = _con.SubjectDateSheet.SingleOrDefault(c => (c.date == dt) && (c.tbl_subjectID == subject.id) && (c.block.id == blocks.id) && (c.shift.id == shift.id));

						if (flag == false)
						{
							MessageBox.Show("Can`t Select Sundays", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
							dateflag = true;
						}
						else if (flag == true)
						{
							dateflag = true;
							if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true || checkBox6.Checked == true || checkBox7.Checked == true || checkBox8.Checked == true || checkBox9.Checked == true)
							{
                                Boolean checkFlag = false;
								if (checkBox1.Checked == true)
								{                                    
									var checkboxid = _con.Block.SingleOrDefault(c => c.name == "Block 1");
                                    var studentCapacity = _con.StudentCapacity.SingleOrDefault(c => (c.tbl_semesterId == semesterId.id) && (c.tbl_courseId == courseId.id));
                                    var years = Convert.ToInt32(SessionComboBox.SelectedItem);
                                    var capacityData = _con.CapacityCalc.SingleOrDefault(c => (c.tbl_shiftId == shift.id) && (c.tbl_blockId == checkboxid.id) && (c.year == years) && (c.date == dt));
                                    if(capacityData!=null)
                                    {
                                        MessageBox.Show("Capcity " + capacityData.capacity.ToString());
                                        MessageBox.Show("Student " + studentCapacity.capacity.ToString());
                                        MessageBox.Show("Chheck " + checkboxid.capacity.ToString());

                                        if(capacityData.capacity==checkboxid.capacity)
                                        {
                                            checkFlag = true;
                                            MessageBox.Show("Block Capacity is full", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else if(capacityData.capacity+studentCapacity.capacity>checkboxid.capacity)
                                        {
                                            checkFlag = true;
                                            MessageBox.Show("Block is not able to hold the student", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            capacityData.capacity += studentCapacity.capacity;
                                            _con.SaveChanges();
                                            var datas = new tbl_subjectDatesheet
                                            {
                                                date = dt,
                                                shift = _con.Shift.FirstOrDefault(c => c.shift == shifts),
                                                subject = _con.Subject.FirstOrDefault(c => c.name == subjects),
                                                block = checkboxid,
                                                session = Convert.ToInt32(SessionComboBox.SelectedItem),
                                                odd_even = oddComboBox.SelectedItem.ToString(),

                                                datesheet = new tbl_datesheet
                                                {
                                                    type = type,
                                                    course = course,
                                                    semester = semester
                                                }
                                            };
                                            _con.SubjectDateSheet.Add(datas);
                                            _con.SaveChanges();
                                        }
                                    }
                                    else
                                    {
                                        var data = new tbl_capacityCalc
                                        {
                                            date = dt,
                                            year = years,
                                            shift = _con.Shift.FirstOrDefault(c => c.shift == shifts),
                                            block = checkboxid,
                                            capacity = studentCapacity.capacity
                                        };
                                        _con.CapacityCalc.Add(data);
                                        _con.SaveChanges();
                                        var datas = new tbl_subjectDatesheet
                                        {
                                            date = dt,
                                            shift = _con.Shift.FirstOrDefault(c => c.shift == shifts),
                                            subject = _con.Subject.FirstOrDefault(c => c.name == subjects),
                                            block = checkboxid,
                                            session = Convert.ToInt32(SessionComboBox.SelectedItem),
                                            odd_even = oddComboBox.SelectedItem.ToString(),

                                            datesheet = new tbl_datesheet
                                            {
                                                type = type,
                                                course = course,
                                                semester = semester
                                            }
                                        };
                                        _con.SubjectDateSheet.Add(datas);
                                        _con.SaveChanges();
                                    }

                                    
								}
								if (checkBox2.Checked == true)
								{                                    
									var checkboxid = _con.Block.SingleOrDefault(c => c.name == "Block 2");
									var datas = new tbl_subjectDatesheet
									{
										date = dt,
										shift = _con.Shift.FirstOrDefault(c => c.shift == shifts),
										subject = _con.Subject.FirstOrDefault(c => c.name == subjects),
										block = checkboxid,
										session = Convert.ToInt32(SessionComboBox.SelectedItem),
										odd_even = oddComboBox.SelectedItem.ToString(),

										datesheet = new tbl_datesheet
										{
											type = type,
											course = course,
											semester = semester
										}
									};
									_con.SubjectDateSheet.Add(datas);
									_con.SaveChanges();
								}
								if (checkBox3.Checked == true)
								{                                    
									var checkboxid = _con.Block.SingleOrDefault(c => c.name == "Block 3");
									var datas = new tbl_subjectDatesheet
									{
										date = dt,
										shift = _con.Shift.FirstOrDefault(c => c.shift == shifts),
										subject = _con.Subject.FirstOrDefault(c => c.name == subjects),
										block = checkboxid,
										session = Convert.ToInt32(SessionComboBox.SelectedItem),
										odd_even = oddComboBox.SelectedItem.ToString(),

										datesheet = new tbl_datesheet
										{
											type = type,
											course = course,
											semester = semester
										}
									};
									_con.SubjectDateSheet.Add(datas);
									_con.SaveChanges();
								}
								if (checkBox4.Checked == true)
								{                                   
									var checkboxid = _con.Block.SingleOrDefault(c => c.name == "Block 4");
									var datas = new tbl_subjectDatesheet
									{
										date = dt,
										shift = _con.Shift.FirstOrDefault(c => c.shift == shifts),
										subject = _con.Subject.FirstOrDefault(c => c.name == subjects),
										block = checkboxid,
										session = Convert.ToInt32(SessionComboBox.SelectedItem),
										odd_even = oddComboBox.SelectedItem.ToString(),

										datesheet = new tbl_datesheet
										{
											type = type,
											course = course,
											semester = semester
										}
									};
									_con.SubjectDateSheet.Add(datas);
									_con.SaveChanges();
								}
								if (checkBox5.Checked == true)
								{                                    
									var checkboxid = _con.Block.SingleOrDefault(c => c.name == "Block 5");
									var datas = new tbl_subjectDatesheet
									{
										date = dt,
										shift = _con.Shift.FirstOrDefault(c => c.shift == shifts),
										subject = _con.Subject.FirstOrDefault(c => c.name == subjects),
										block = checkboxid,
										session = Convert.ToInt32(SessionComboBox.SelectedItem),
										odd_even = oddComboBox.SelectedItem.ToString(),

										datesheet = new tbl_datesheet
										{
											type = type,
											course = course,
											semester = semester
										}
									};
									_con.SubjectDateSheet.Add(datas);
									_con.SaveChanges();
								}
								if (checkBox6.Checked == true)
								{                                   
									var checkboxid = _con.Block.SingleOrDefault(c => c.name == "Block 6");
									var datas = new tbl_subjectDatesheet
									{
										date = dt,
										shift = _con.Shift.FirstOrDefault(c => c.shift == shifts),
										subject = _con.Subject.FirstOrDefault(c => c.name == subjects),
										block = checkboxid,
										session = Convert.ToInt32(SessionComboBox.SelectedItem),
										odd_even = oddComboBox.SelectedItem.ToString(),

										datesheet = new tbl_datesheet
										{
											type = type,
											course = course,
											semester = semester
										}
									};
									_con.SubjectDateSheet.Add(datas);
									_con.SaveChanges();
								}
								if (checkBox7.Checked == true)
								{                                   
									var checkboxid = _con.Block.SingleOrDefault(c => c.name == "Block 7");
									var datas = new tbl_subjectDatesheet
									{
										date = dt,
										shift = _con.Shift.FirstOrDefault(c => c.shift == shifts),
										subject = _con.Subject.FirstOrDefault(c => c.name == subjects),
										block = checkboxid,
										session = Convert.ToInt32(SessionComboBox.SelectedItem),
										odd_even = oddComboBox.SelectedItem.ToString(),

										datesheet = new tbl_datesheet
										{
											type = type,
											course = course,
											semester = semester
										}
									};
									_con.SubjectDateSheet.Add(datas);
									_con.SaveChanges();
								}
								if (checkBox8.Checked == true)
								{                                
									var checkboxid = _con.Block.SingleOrDefault(c => c.name == "Block 8");
									var datas = new tbl_subjectDatesheet
									{
										date = dt,
										shift = _con.Shift.FirstOrDefault(c => c.shift == shifts),
										subject = _con.Subject.FirstOrDefault(c => c.name == subjects),
										block = checkboxid,
										session = Convert.ToInt32(SessionComboBox.SelectedItem),
										odd_even = oddComboBox.SelectedItem.ToString(),

										datesheet = new tbl_datesheet
										{
											type = type,
											course = course,
											semester = semester
										}
									};
									_con.SubjectDateSheet.Add(datas);
									_con.SaveChanges();
								}
								if (checkBox9.Checked == true)
								{                                     
									var checkboxid = _con.Block.SingleOrDefault(c => c.name == "Block 9");
									var datas = new tbl_subjectDatesheet
									{
										date = dt,
										shift = _con.Shift.FirstOrDefault(c => c.shift == shifts),
										subject = _con.Subject.FirstOrDefault(c => c.name == subjects),
										block = checkboxid,
										session = Convert.ToInt32(SessionComboBox.SelectedItem),
										odd_even = oddComboBox.SelectedItem.ToString(),

										datesheet = new tbl_datesheet
										{
											type = type,
											course = course,
											semester = semester
										}
									};
									_con.SubjectDateSheet.Add(datas);
									_con.SaveChanges();

								}
                                if(checkFlag == false)
                                {
                                    MessageBox.Show(subjects.ToString() + " Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                                }
                                else
                                {
                                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                                }
                                

                            }
							else
							{
								MessageBox.Show("Please Select the block!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}

							//MessageBox.Show(subjects.ToString() + "Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							//dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
						}
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}//Closing saving data block

		private void button2_Click(object sender, EventArgs e)
		{
			//ManageDateSheet obj = new ManageDateSheet();
			//this.Hide();
			//obj.Show();
		}

		//For Checking that block is assigned to which department 
		public void checkboxCheck(string blockname)
		{
			int count = 1;
			StringBuilder sb = new StringBuilder();
			try
			{
				var sessions = Convert.ToInt32(SessionComboBox.SelectedItem);
				var block_id = _con.Block.SingleOrDefault(c => c.name == blockname);
				var data = _con.SubjectDateSheet.Where(c => (c.block.id == block_id.id) && (c.session == sessions) && (c.odd_even == oddComboBox.SelectedItem.ToString())).ToList();
				if (data != null)
				{
					foreach (var datas in data)
					{
						var courseId = _con.DateSheet.SingleOrDefault(c => c.id == datas.tbl_datesheetId);
						var courseName = _con.Courses.SingleOrDefault(c => c.id == courseId.tbl_courseId);
						var semesterName = _con.Semester.SingleOrDefault(c => c.id == courseId.tbl_semesterId);

						sb.Append(count + ". " + blockname + " is assigned to " + courseName.name + " of " + semesterName.name + " on " + datas.date.ToString("dd/MM/yyyy") + "\n");
						count++;
					}
					String str = "";
					if (!String.IsNullOrEmpty(str = sb.ToString()))
						MessageBox.Show(sb.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
				blocksList.Append("Block 1").AppendLine();
				checkboxCheck("Block 1");
			}
			else if(checkBox1.Checked == false)
			{
				int indexLen =blocksList.ToString().LastIndexOf("Block 1");
				blocksList.Remove(indexLen, "Block 1".Length);
			}
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked == true)
			{
				blocksList.Append("Block 2").AppendLine();
				checkboxCheck("Block 2");
			}
			else if (checkBox2.Checked == false)
			{
				int indexLen = blocksList.ToString().LastIndexOf("Block 2");
				blocksList.Remove(indexLen, "Block 2".Length);

			}
		}

		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox3.Checked == true)
			{
				blocksList.Append("Block 3").AppendLine();
				checkboxCheck("Block 3");
			}
			else if (checkBox3.Checked == false)
			{
				int indexLen = blocksList.ToString().LastIndexOf("Block 3");
				blocksList.Remove(indexLen, "Block 3".Length);

			}
		}

		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox4.Checked == true)
			{
				blocksList.Append("Block 4").AppendLine();
				checkboxCheck("Block 4");
			}
			else if (checkBox4.Checked == false)
			{
				int indexLen = blocksList.ToString().LastIndexOf("Block 4");
				blocksList.Remove(indexLen, "Block 4".Length);

			}
		}

		private void checkBox5_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox5.Checked == true)
			{
				blocksList.Append("Block 5").AppendLine();
				checkboxCheck("Block 5");
			}
			else if (checkBox5.Checked == false)
			{
				int indexLen = blocksList.ToString().LastIndexOf("Block 5");
				blocksList.Remove(indexLen, "Block 5".Length);

			}
		}

		private void checkBox6_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox6.Checked == true)
			{

				blocksList.Append("Block 6").AppendLine();
				checkboxCheck("Block 6");
			}
			else if (checkBox6.Checked == false)
			{
				int indexLen = blocksList.ToString().LastIndexOf("Block 6");
				blocksList.Remove(indexLen, "Block 6".Length);

			}
		}

		private void checkBox7_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox7.Checked == true)
			{
				blocksList.Append("Block 7").AppendLine();
				checkboxCheck("Block 7");
			}
			else if (checkBox7.Checked == false)
			{
				int indexLen = blocksList.ToString().LastIndexOf("Block 7");
				blocksList.Remove(indexLen, "Block 7".Length);

			}
		}

		private void checkBox8_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox8.Checked == true)
			{
				blocksList.Append("Block 8").AppendLine();
				checkboxCheck("Block 8");
			}
			else if (checkBox8.Checked == false)
			{
				int indexLen = blocksList.ToString().LastIndexOf("Block 8");
				blocksList.Remove(indexLen, "Block 8".Length);

			}
		}

		private void checkBox9_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox9.Checked == true)
			{
				blocksList.Append("Block 9").AppendLine();
				checkboxCheck("Block 9");
			}
			else if (checkBox9.Checked == false)
			{
				int indexLen = blocksList.ToString().LastIndexOf("Block 9");
				blocksList.Remove(indexLen, "Block 9".Length);

			}
		}

		private void btnexport_Click(object sender, EventArgs e)
		{
			try
			{
				saveFileDialog.InitialDirectory = "C:";
				saveFileDialog.Title = "Save to Excel File";
				saveFileDialog.FileName = "DateSheet_" + box_semester.SelectedItem.ToString()+ "_" + box_course.SelectedItem.ToString() + "_as_on_ " + DateTime.Now.ToString("dd.mm.yyyy");
				saveFileDialog.Filter = "Excel Files|*.xlsx|Excel Files(2003)|*.xls";
				if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
				{
					Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
					ExcelApp.Application.Workbooks.Add(Type.Missing);

					//Change properties of the Workbook
					ExcelApp.Columns.ColumnWidth = 15;

					ExcelApp.get_Range("d1", "f1").Merge(false);
					ExcelApp.Cells[1, 4] = "Chandigarh University, Gharuan";
					ExcelApp.Cells[1, 4].Font.Bold = true;
					ExcelApp.Cells[1, 4].Font.Size = 18;
					ExcelApp.Cells[1, 4].HorizontalAlignment = 3;
					ExcelApp.Cells[1, 4].VerticalAlignment = 3;

					ExcelApp.Cells[2, 2] = "Final Theory Date Sheet of " + box_semester.SelectedItem.ToString() + " " + box_type.SelectedItem.ToString() + " for " + box_dept.SelectedItem.ToString() + "-" + SessionComboBox.SelectedItem.ToString();
					ExcelApp.Cells[2, 2].Font.Bold = true;
					ExcelApp.Cells[2, 2].Font.Size = 18;

					ExcelApp.Cells[4, 1] = "Course & "; //Date isse line mai
					ExcelApp.Cells[4, 1].Font.Size = 14;
					ExcelApp.Cells[4, 1].Font.Bold = true;
					ExcelApp.Cells[4, 1].HorizontalAlignment = 3;
					ExcelApp.Cells[4, 1].VerticalAlignment = 3;
					ExcelApp.Cells[4, 1].BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
																	  Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
																	  Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);

					ExcelApp.Cells[5, 1] = "sem"; //Time isse line mai
					ExcelApp.Cells[5, 1].Font.Size = 14;
					ExcelApp.Cells[5, 1].Font.Bold = true;
					ExcelApp.Cells[5, 1].HorizontalAlignment = 3;
					ExcelApp.Cells[5, 1].VerticalAlignment = 3;
					ExcelApp.Cells[5, 1].BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
																	  Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
																	  Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
					ExcelApp.get_Range("b4", "b5").Merge(false);
					ExcelApp.Cells[4, 2] = "Exam Center";
					ExcelApp.Cells[4, 2].Font.Size = 14;
					ExcelApp.Cells[4, 2].Font.Bold = true;
					ExcelApp.Cells[4, 2].HorizontalAlignment = 3;
					ExcelApp.Cells[4, 2].VerticalAlignment = 3;
					ExcelApp.Cells[4, 2].BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
																	  Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
																	  Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);

					ExcelApp.Cells[6, 2] = blocksList.ToString();
					//MessageBox.Show(blocksList.ToString());
					ExcelApp.Cells[6, 2].Font.Size = 14;
					ExcelApp.Cells[6, 2].Font.Bold = true;
					ExcelApp.Cells[6, 2].HorizontalAlignment = 3;
					ExcelApp.Cells[6, 2].VerticalAlignment = 3;
					ExcelApp.Cells[6, 2].BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
																	  Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
																	  Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);



					ExcelApp.Cells[6, 1] = box_course.SelectedItem.ToString() + "\n" + box_semester.SelectedItem.ToString() + "\n " + box_type.SelectedItem.ToString();
					ExcelApp.Cells[6, 1].Font.Bold = true;
					ExcelApp.Cells[6, 1].Font.Size = 12;
					ExcelApp.Cells[6, 1].HorizontalAlignment = 3;
					ExcelApp.Cells[6, 1].VerticalAlignment = 3;
					ExcelApp.Cells[6, 1].BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
																	  Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
																	  Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);

					for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
					{
						for (int j = 0; j < dataGridView1.Columns.Count; j++)
						{
							if (j == 1)
							{
								string date = dataGridView1.Rows[i].Cells[j].Value as String;
								ExcelApp.Cells[4, i + 3] = date;
								ExcelApp.Cells[4, i + 3].Font.Size = 12;
								ExcelApp.Cells[4, i + 3].HorizontalAlignment = 3;
								ExcelApp.Cells[4, i + 3].VerticalAlignment = 3;
								ExcelApp.Cells[4, i + 3].BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
																	  Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
																	  Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
							}
							if (j == 0)
							{                                
								string subjects = dataGridView1.Rows[i].Cells[j].Value as String;
								ExcelApp.Cells[6, i + 3] = subjects;
								ExcelApp.Cells[6, i + 3].Font.Size = 11;
								ExcelApp.Cells[6, i + 3].HorizontalAlignment = 3;
								//ExcelApp.Cells[6, i + 2].VerticalAlignment = 3;
								ExcelApp.Cells[6, i + 3].BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
																	  Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
																	  Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
							}
							if (j == 2)
							{
								string shifts = dataGridView1.Rows[i].Cells[j].Value as String;
								if (shifts.Equals("Shift 1"))
									ExcelApp.Cells[5, i + 3] = "9:30-12:30am";
								else if (shifts.Equals("Shift 2"))
									ExcelApp.Cells[5, i + 3] = "1:30-4:30pm";
								else
									ExcelApp.Cells[5, i + 3] = "";
								ExcelApp.Cells[5, i + 3].Font.Size = 11;
								ExcelApp.Cells[5, i + 3].HorizontalAlignment = 3;
								//ExcelApp.Cells[5, i + 2].VerticalAlignment = 3;
								ExcelApp.Cells[5, i + 3].BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
																	  Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
																	  Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
							}
						}
					}
					//for bolding the text
					Microsoft.Office.Interop.Excel.Range formatRange;
					formatRange = ExcelApp.get_Range("b4", "b5");
					formatRange.EntireRow.Font.Bold = true;


					formatRange = ExcelApp.get_Range("a1", "a2");
					formatRange.EntireRow.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
																	  Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
																	  Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
					//formatRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
					//formatRange.Font.Size = 10;               

					ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog.FileName.ToString());
					ExcelApp.ActiveWorkbook.Saved = true;
					ExcelApp.Quit();
					MessageBox.Show("Successfully Exported to Excel", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}

			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		
	}
}