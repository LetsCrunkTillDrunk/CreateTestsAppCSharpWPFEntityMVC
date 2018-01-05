namespace TestDesigner
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnAddSub = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAddExam = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAddQuestion = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRedact = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPreview = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.tsmiConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.подключениеКБазеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.иToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьПредметToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьЭкзаменToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьВопросToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddSub = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddEx = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddQuest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditSub = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditEx = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditQuest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelSub = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelEx = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelQuest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewSub = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewEx = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewQuest = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiConnect,
            this.иToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(564, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAddSub,
            this.tsBtnAddExam,
            this.tsBtnAddQuestion,
            this.tsBtnRedact,
            this.tsBtnPreview,
            this.tsBtnDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(564, 40);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnAddSub
            // 
            this.tsBtnAddSub.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAddSub.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAddSub.Image")));
            this.tsBtnAddSub.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddSub.Name = "tsBtnAddSub";
            this.tsBtnAddSub.Size = new System.Drawing.Size(39, 37);
            this.tsBtnAddSub.Text = "Добавить предмет";
            this.tsBtnAddSub.Click += new System.EventHandler(this.tsBtnAddSub_Click);
            // 
            // tsBtnAddExam
            // 
            this.tsBtnAddExam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAddExam.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAddExam.Image")));
            this.tsBtnAddExam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddExam.Name = "tsBtnAddExam";
            this.tsBtnAddExam.Size = new System.Drawing.Size(39, 37);
            this.tsBtnAddExam.Text = "Добавить тест";
            this.tsBtnAddExam.Click += new System.EventHandler(this.tsBtnAddExam_Click);
            // 
            // tsBtnAddQuestion
            // 
            this.tsBtnAddQuestion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAddQuestion.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAddQuestion.Image")));
            this.tsBtnAddQuestion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddQuestion.Name = "tsBtnAddQuestion";
            this.tsBtnAddQuestion.Size = new System.Drawing.Size(39, 37);
            this.tsBtnAddQuestion.Text = "Добавить вопрос";
            this.tsBtnAddQuestion.Click += new System.EventHandler(this.tsBtnAddQuestion_Click);
            // 
            // tsBtnRedact
            // 
            this.tsBtnRedact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnRedact.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRedact.Image")));
            this.tsBtnRedact.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRedact.Name = "tsBtnRedact";
            this.tsBtnRedact.Size = new System.Drawing.Size(39, 37);
            this.tsBtnRedact.Text = "Редактирование";
            this.tsBtnRedact.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsBtnPreview
            // 
            this.tsBtnPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnPreview.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnPreview.Image")));
            this.tsBtnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPreview.Name = "tsBtnPreview";
            this.tsBtnPreview.Size = new System.Drawing.Size(39, 37);
            this.tsBtnPreview.Text = "Просмотр";
            this.tsBtnPreview.Click += new System.EventHandler(this.tsBtnPreview_Click);
            // 
            // tsBtnDelete
            // 
            this.tsBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDelete.Image")));
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Size = new System.Drawing.Size(39, 37);
            this.tsBtnDelete.Text = "Удаление элемента";
            this.tsBtnDelete.Click += new System.EventHandler(this.tsBtnDelete_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainer1.Location = new System.Drawing.Point(0, 64);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(216, 307);
            this.splitContainer1.SplitterDistance = 132;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 16;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(212, 128);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "html5-original.png");
            this.imageList1.Images.SetKeyName(1, "javascript-original.png");
            this.imageList1.Images.SetKeyName(2, "python-original.png");
            this.imageList1.Images.SetKeyName(3, "php-original.png");
            this.imageList1.Images.SetKeyName(4, "react-original.png");
            this.imageList1.Images.SetKeyName(5, "ruby-original.png");
            this.imageList1.Images.SetKeyName(6, "sass-original.png");
            this.imageList1.Images.SetKeyName(7, "cplusplus-original.png");
            this.imageList1.Images.SetKeyName(8, "csharp-original.png");
            this.imageList1.Images.SetKeyName(9, "git-original.png");
            this.imageList1.Images.SetKeyName(10, "java-original.png");
            this.imageList1.Images.SetKeyName(11, "windows8-original.png");
            this.imageList1.Images.SetKeyName(12, "angularjs-original.png");
            this.imageList1.Images.SetKeyName(13, "android-original.png");
            this.imageList1.Images.SetKeyName(14, "c-original.png");
            this.imageList1.Images.SetKeyName(15, "script-icon.png");
            this.imageList1.Images.SetKeyName(16, "Help-icon.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "database-add-icon.png");
            this.imageList2.Images.SetKeyName(1, "folder-add-icon.png");
            this.imageList2.Images.SetKeyName(2, "mail-add-icon.png");
            this.imageList2.Images.SetKeyName(3, "administrative-tools-icon.png");
            // 
            // tsmiConnect
            // 
            this.tsmiConnect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подключениеКБазеToolStripMenuItem,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.tsmiConnect.Name = "tsmiConnect";
            this.tsmiConnect.Size = new System.Drawing.Size(48, 20);
            this.tsmiConnect.Text = "Файл";
            // 
            // подключениеКБазеToolStripMenuItem
            // 
            this.подключениеКБазеToolStripMenuItem.Name = "подключениеКБазеToolStripMenuItem";
            this.подключениеКБазеToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.подключениеКБазеToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.подключениеКБазеToolStripMenuItem.Text = "Подключение к базе";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(227, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // иToolStripMenuItem
            // 
            this.иToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьПредметToolStripMenuItem,
            this.добавитьЭкзаменToolStripMenuItem,
            this.добавитьВопросToolStripMenuItem,
            this.рToolStripMenuItem});
            this.иToolStripMenuItem.Name = "иToolStripMenuItem";
            this.иToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.иToolStripMenuItem.Text = "Инструменты";
            // 
            // добавитьПредметToolStripMenuItem
            // 
            this.добавитьПредметToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddSub,
            this.tsmiAddEx,
            this.tsmiAddQuest});
            this.добавитьПредметToolStripMenuItem.Name = "добавитьПредметToolStripMenuItem";
            this.добавитьПредметToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.добавитьПредметToolStripMenuItem.Text = "Добавить ";
            // 
            // добавитьЭкзаменToolStripMenuItem
            // 
            this.добавитьЭкзаменToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditSub,
            this.tsmiEditEx,
            this.tsmiEditQuest});
            this.добавитьЭкзаменToolStripMenuItem.Name = "добавитьЭкзаменToolStripMenuItem";
            this.добавитьЭкзаменToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.добавитьЭкзаменToolStripMenuItem.Text = "Редактировать";
            // 
            // добавитьВопросToolStripMenuItem
            // 
            this.добавитьВопросToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDelSub,
            this.tsmiDelEx,
            this.tsmiDelQuest});
            this.добавитьВопросToolStripMenuItem.Name = "добавитьВопросToolStripMenuItem";
            this.добавитьВопросToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.добавитьВопросToolStripMenuItem.Text = "Удалить";
            // 
            // рToolStripMenuItem
            // 
            this.рToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewSub,
            this.tsmiViewEx,
            this.tsmiViewQuest});
            this.рToolStripMenuItem.Name = "рToolStripMenuItem";
            this.рToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.рToolStripMenuItem.Text = "Просмотр";
            // 
            // tsmiAddSub
            // 
            this.tsmiAddSub.Name = "tsmiAddSub";
            this.tsmiAddSub.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiAddSub.Size = new System.Drawing.Size(162, 22);
            this.tsmiAddSub.Text = "Предмет";
            this.tsmiAddSub.Click += new System.EventHandler(this.tsBtnAddSub_Click);
            // 
            // tsmiAddEx
            // 
            this.tsmiAddEx.Name = "tsmiAddEx";
            this.tsmiAddEx.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tsmiAddEx.Size = new System.Drawing.Size(162, 22);
            this.tsmiAddEx.Text = "Экзамен";
            this.tsmiAddEx.Click += new System.EventHandler(this.tsBtnAddExam_Click);
            // 
            // tsmiAddQuest
            // 
            this.tsmiAddQuest.Name = "tsmiAddQuest";
            this.tsmiAddQuest.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.tsmiAddQuest.Size = new System.Drawing.Size(162, 22);
            this.tsmiAddQuest.Text = "Вопрос";
            this.tsmiAddQuest.Click += new System.EventHandler(this.tsBtnAddQuestion_Click);
            // 
            // tsmiEditSub
            // 
            this.tsmiEditSub.Name = "tsmiEditSub";
            this.tsmiEditSub.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.tsmiEditSub.Size = new System.Drawing.Size(194, 22);
            this.tsmiEditSub.Text = "Предмет";
            this.tsmiEditSub.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsmiEditEx
            // 
            this.tsmiEditEx.Name = "tsmiEditEx";
            this.tsmiEditEx.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.tsmiEditEx.Size = new System.Drawing.Size(194, 22);
            this.tsmiEditEx.Text = "Экзамен";
            this.tsmiEditEx.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsmiEditQuest
            // 
            this.tsmiEditQuest.Name = "tsmiEditQuest";
            this.tsmiEditQuest.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.tsmiEditQuest.Size = new System.Drawing.Size(194, 22);
            this.tsmiEditQuest.Text = "Вопрос";
            this.tsmiEditQuest.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsmiDelSub
            // 
            this.tsmiDelSub.Name = "tsmiDelSub";
            this.tsmiDelSub.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.tsmiDelSub.Size = new System.Drawing.Size(190, 22);
            this.tsmiDelSub.Text = "Предмет";
            this.tsmiDelSub.Click += new System.EventHandler(this.tsBtnDelete_Click);
            // 
            // tsmiDelEx
            // 
            this.tsmiDelEx.Name = "tsmiDelEx";
            this.tsmiDelEx.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.tsmiDelEx.Size = new System.Drawing.Size(190, 22);
            this.tsmiDelEx.Text = "Экзамен";
            this.tsmiDelEx.Click += new System.EventHandler(this.tsBtnDelete_Click);
            // 
            // tsmiDelQuest
            // 
            this.tsmiDelQuest.Name = "tsmiDelQuest";
            this.tsmiDelQuest.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.tsmiDelQuest.Size = new System.Drawing.Size(190, 22);
            this.tsmiDelQuest.Text = "Вопрос";
            this.tsmiDelQuest.Click += new System.EventHandler(this.tsBtnDelete_Click);
            // 
            // tsmiViewSub
            // 
            this.tsmiViewSub.Name = "tsmiViewSub";
            this.tsmiViewSub.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.tsmiViewSub.Size = new System.Drawing.Size(185, 22);
            this.tsmiViewSub.Text = "Предмет";
            this.tsmiViewSub.Click += new System.EventHandler(this.tsBtnPreview_Click);
            // 
            // tsmiViewEx
            // 
            this.tsmiViewEx.Name = "tsmiViewEx";
            this.tsmiViewEx.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.E)));
            this.tsmiViewEx.Size = new System.Drawing.Size(185, 22);
            this.tsmiViewEx.Text = "Экзамен";
            this.tsmiViewEx.Click += new System.EventHandler(this.tsBtnPreview_Click);
            // 
            // tsmiViewQuest
            // 
            this.tsmiViewQuest.Name = "tsmiViewQuest";
            this.tsmiViewQuest.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Q)));
            this.tsmiViewQuest.Size = new System.Drawing.Size(185, 22);
            this.tsmiViewQuest.Text = "Вопрос";
            this.tsmiViewQuest.Click += new System.EventHandler(this.tsBtnPreview_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 371);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Дизайнер тестов";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton tsBtnAddSub;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ToolStripButton tsBtnAddExam;
        private System.Windows.Forms.ToolStripButton tsBtnAddQuestion;
        private System.Windows.Forms.ToolStripButton tsBtnRedact;
        private System.Windows.Forms.ToolStripButton tsBtnPreview;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiConnect;
        private System.Windows.Forms.ToolStripMenuItem подключениеКБазеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem иToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьПредметToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddSub;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddEx;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddQuest;
        private System.Windows.Forms.ToolStripMenuItem добавитьЭкзаменToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditSub;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditEx;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditQuest;
        private System.Windows.Forms.ToolStripMenuItem добавитьВопросToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelSub;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelEx;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelQuest;
        private System.Windows.Forms.ToolStripMenuItem рToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewSub;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewEx;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewQuest;
    }
}