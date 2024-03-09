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
            this.tsmДобавитьType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmИзменитьTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmVolunteer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmДобавитьVolunteer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiИзменитьВолонтёра = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmУдалитьVolunteer = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmEvents = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmДобавитьEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmИзменитьEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmУдалитьEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьСобытиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьВолонтёраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmType.SuspendLayout();
            this.ctmVolunteer.SuspendLayout();
            this.ctmEvents.SuspendLayout();
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
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ctmType
            // 
            this.ctmType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmДобавитьType,
            this.добавитьСобытиеToolStripMenuItem,
            this.toolStripMenuItem1,
            this.tsmИзменитьTypes,
            this.удалитьToolStripMenuItem});
            this.ctmType.Name = "ctmType";
            this.ctmType.Size = new System.Drawing.Size(236, 98);
            // 
            // tsmДобавитьType
            // 
            this.tsmДобавитьType.Name = "tsmДобавитьType";
            this.tsmДобавитьType.Size = new System.Drawing.Size(235, 22);
            this.tsmДобавитьType.Text = "Добавить тип мероприятий...";
            this.tsmДобавитьType.Click += new System.EventHandler(this.tsmДобавитьType_Click);
            // 
            // tsmИзменитьTypes
            // 
            this.tsmИзменитьTypes.Name = "tsmИзменитьTypes";
            this.tsmИзменитьTypes.Size = new System.Drawing.Size(180, 22);
            this.tsmИзменитьTypes.Text = "Изменить...";
            this.tsmИзменитьTypes.Click += new System.EventHandler(this.tsmИзменитьTypes_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.ctmVolunteer.Size = new System.Drawing.Size(138, 76);
            // 
            // tsmДобавитьVolunteer
            // 
            this.tsmДобавитьVolunteer.Name = "tsmДобавитьVolunteer";
            this.tsmДобавитьVolunteer.Size = new System.Drawing.Size(137, 22);
            this.tsmДобавитьVolunteer.Text = "Добавить...";
            this.tsmДобавитьVolunteer.Click += new System.EventHandler(this.tsmДобавитьVolunteer_Click);
            // 
            // tsiИзменитьВолонтёра
            // 
            this.tsiИзменитьВолонтёра.Name = "tsiИзменитьВолонтёра";
            this.tsiИзменитьВолонтёра.Size = new System.Drawing.Size(137, 22);
            this.tsiИзменитьВолонтёра.Text = "Изменить...";
            this.tsiИзменитьВолонтёра.Click += new System.EventHandler(this.tsiИзменитьВолонтёра_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(134, 6);
            // 
            // tsmУдалитьVolunteer
            // 
            this.tsmУдалитьVolunteer.Name = "tsmУдалитьVolunteer";
            this.tsmУдалитьVolunteer.Size = new System.Drawing.Size(137, 22);
            this.tsmУдалитьVolunteer.Text = "Удалить";
            this.tsmУдалитьVolunteer.Click += new System.EventHandler(this.tsmУдалитьVolunteer_Click);
            // 
            // ctmEvents
            // 
            this.ctmEvents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmДобавитьEvents,
            this.добавитьВолонтёраToolStripMenuItem,
            this.toolStripMenuItem3,
            this.tsmИзменитьEvents,
            this.tsmУдалитьEvents});
            this.ctmEvents.Name = "ctmEvents";
            this.ctmEvents.Size = new System.Drawing.Size(197, 98);
            // 
            // tsmДобавитьEvents
            // 
            this.tsmДобавитьEvents.Name = "tsmДобавитьEvents";
            this.tsmДобавитьEvents.Size = new System.Drawing.Size(196, 22);
            this.tsmДобавитьEvents.Text = "Добавить событие...";
            this.tsmДобавитьEvents.Click += new System.EventHandler(this.tsmДобавитьEvents_Click);
            // 
            // tsmИзменитьEvents
            // 
            this.tsmИзменитьEvents.Name = "tsmИзменитьEvents";
            this.tsmИзменитьEvents.Size = new System.Drawing.Size(137, 22);
            this.tsmИзменитьEvents.Text = "Изменить...";
            this.tsmИзменитьEvents.Click += new System.EventHandler(this.tsmИзменитьEvents_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(134, 6);
            // 
            // tsmУдалитьEvents
            // 
            this.tsmУдалитьEvents.Name = "tsmУдалитьEvents";
            this.tsmУдалитьEvents.Size = new System.Drawing.Size(137, 22);
            this.tsmУдалитьEvents.Text = "Удалить";
            this.tsmУдалитьEvents.Click += new System.EventHandler(this.tsmУдалитьEvents_Click);
            // 
            // добавитьСобытиеToolStripMenuItem
            // 
            this.добавитьСобытиеToolStripMenuItem.Name = "добавитьСобытиеToolStripMenuItem";
            this.добавитьСобытиеToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.добавитьСобытиеToolStripMenuItem.Text = "Добавить событие...";
            this.добавитьСобытиеToolStripMenuItem.Click += new System.EventHandler(this.добавитьСобытиеToolStripMenuItem_Click);
            // 
            // добавитьВолонтёраToolStripMenuItem
            // 
            this.добавитьВолонтёраToolStripMenuItem.Name = "добавитьВолонтёраToolStripMenuItem";
            this.добавитьВолонтёраToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.добавитьВолонтёраToolStripMenuItem.Text = "Добавить волонтёра...";
            this.добавитьВолонтёраToolStripMenuItem.Click += new System.EventHandler(this.добавитьВолонтёраToolStripMenuItem_Click);
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
            this.ctmEvents.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ContextMenuStrip ctmType;
        private System.Windows.Forms.ToolStripMenuItem tsmДобавитьType;
        private System.Windows.Forms.ToolStripMenuItem tsmИзменитьTypes;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctmVolunteer;
        private System.Windows.Forms.ToolStripMenuItem tsmДобавитьVolunteer;
        private System.Windows.Forms.ToolStripMenuItem tsiИзменитьВолонтёра;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmУдалитьVolunteer;
        private System.Windows.Forms.ContextMenuStrip ctmEvents;
        private System.Windows.Forms.ToolStripMenuItem tsmДобавитьEvents;
        private System.Windows.Forms.ToolStripMenuItem tsmИзменитьEvents;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmУдалитьEvents;
        private System.Windows.Forms.ToolStripMenuItem добавитьСобытиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьВолонтёраToolStripMenuItem;
    }
}

