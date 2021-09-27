
namespace UserMaintenance
{
    partial class Form1
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
            this.listUsers = new System.Windows.Forms.ListBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listUsers
            // 
            this.listUsers.FormattingEnabled = true;
            this.listUsers.Location = new System.Drawing.Point(2, 4);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(214, 433);
            this.listUsers.TabIndex = 0;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(232, 9);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(35, 13);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "label1";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(288, 6);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(223, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(235, 45);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(276, 29);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "button1";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(235, 92);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(276, 29);
            this.btnWrite.TabIndex = 6;
            this.btnWrite.Text = "button1";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(235, 139);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(276, 30);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "button1";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 442);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.listUsers);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listUsers;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnDelete;
    }
}

