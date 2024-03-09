namespace TreeView_CRUD
{
    partial class TreeForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeView = new System.Windows.Forms.TreeView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.ctmType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmVolunteer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmДобавитьVolunteer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiИзменитьВолонтёра = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmУдалитьVolunteer = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmType.SuspendLayout();
            this.ctmVolunteer.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(12, 12);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(392, 368);
            this.treeView.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(292, 386);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(112, 36);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ctmType
            // 
            this.ctmType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.toolStripMenuItem1,
            this.удалитьToolStripMenuItem});
            this.ctmType.Name = "ctmType";
            this.ctmType.Size = new System.Drawing.Size(138, 76);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить...";
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 6);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // ctmVolunteer
            // 
            this.ctmVolunteer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmДобавитьVolunteer,
            this.tsiИзменитьВолонтёра,
            this.toolStripMenuItem2,
            this.tsmУдалитьVolunteer});
            this.ctmVolunteer.Name = "ctmVolunteer";
            this.ctmVolunteer.Size = new System.Drawing.Size(181, 98);
            // 
            // tsmДобавитьVolunteer
            // 
            this.tsmДобавитьVolunteer.Name = "tsmДобавитьVolunteer";
            this.tsmДобавитьVolunteer.Size = new System.Drawing.Size(180, 22);
            this.tsmДобавитьVolunteer.Text = "Добавить...";
            this.tsmДобавитьVolunteer.Click += new System.EventHandler(this.tsmДобавитьVolunteer_Click);
            // 
            // tsiИзменитьВолонтёра
            // 
            this.tsiИзменитьВолонтёра.Name = "tsiИзменитьВолонтёра";
            this.tsiИзменитьВолонтёра.Size = new System.Drawing.Size(180, 22);
            this.tsiИзменитьВолонтёра.Text = "Изменить...";
            this.tsiИзменитьВолонтёра.Click += new System.EventHandler(this.tsiИзменитьВолонтёра_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmУдалитьVolunteer
            // 
            this.tsmУдалитьVolunteer.Name = "tsmУдалитьVolunteer";
            this.tsmУдалитьVolunteer.Size = new System.Drawing.Size(180, 22);
            this.tsmУдалитьVolunteer.Text = "Удалить";
            this.tsmУдалитьVolunteer.Click += new System.EventHandler(this.tsmУдалитьVolunteer_Click);
            // 
            // TreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 433);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.treeView);
            this.Name = "TreeForm";
            this.Text = "Form1";
            this.ctmType.ResumeLayout(false);
            this.ctmVolunteer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ContextMenuStrip ctmType;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctmVolunteer;
        private System.Windows.Forms.ToolStripMenuItem tsmДобавитьVolunteer;
        private System.Windows.Forms.ToolStripMenuItem tsiИзменитьВолонтёра;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmУдалитьVolunteer;
    }
}

