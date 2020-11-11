namespace New_Lib
{
    partial class LibraryForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdateOrAdd = new System.Windows.Forms.Button();
            this.buttonTakeIt = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.textBoxSelectedID = new System.Windows.Forms.TextBox();
            this.dataGridViewCatalog = new System.Windows.Forms.DataGridView();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.booksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publishingHousesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.membersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publishingHouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewMyBooks = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonReturned = new System.Windows.Forms.Button();
            this.textBoxOnHands = new System.Windows.Forms.TextBox();
            this.dataGridViewOnHands = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCatalog)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyBooks)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOnHands)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1171, 542);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonUpdate);
            this.tabPage1.Controls.Add(this.buttonDelete);
            this.tabPage1.Controls.Add(this.buttonUpdateOrAdd);
            this.tabPage1.Controls.Add(this.buttonTakeIt);
            this.tabPage1.Controls.Add(this.buttonSearch);
            this.tabPage1.Controls.Add(this.textBoxSearch);
            this.tabPage1.Controls.Add(this.textBoxSelectedID);
            this.tabPage1.Controls.Add(this.dataGridViewCatalog);
            this.tabPage1.Controls.Add(this.menuStrip2);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1163, 509);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Catalog";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(662, 469);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(161, 29);
            this.buttonUpdate.TabIndex = 11;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(829, 469);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(161, 29);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdateOrAdd
            // 
            this.buttonUpdateOrAdd.Location = new System.Drawing.Point(996, 469);
            this.buttonUpdateOrAdd.Name = "buttonUpdateOrAdd";
            this.buttonUpdateOrAdd.Size = new System.Drawing.Size(161, 29);
            this.buttonUpdateOrAdd.TabIndex = 9;
            this.buttonUpdateOrAdd.Text = "Add";
            this.buttonUpdateOrAdd.UseVisualStyleBackColor = true;
            this.buttonUpdateOrAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonTakeIt
            // 
            this.buttonTakeIt.Location = new System.Drawing.Point(485, 469);
            this.buttonTakeIt.Name = "buttonTakeIt";
            this.buttonTakeIt.Size = new System.Drawing.Size(161, 29);
            this.buttonTakeIt.TabIndex = 8;
            this.buttonTakeIt.Text = "Take it";
            this.buttonTakeIt.UseVisualStyleBackColor = true;
            this.buttonTakeIt.Click += new System.EventHandler(this.buttonTakeIt_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(255, 469);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(161, 29);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "Search book";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSearch.Location = new System.Drawing.Point(8, 469);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(241, 29);
            this.textBoxSearch.TabIndex = 6;
            // 
            // textBoxSelectedID
            // 
            this.textBoxSelectedID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSelectedID.Location = new System.Drawing.Point(422, 469);
            this.textBoxSelectedID.Name = "textBoxSelectedID";
            this.textBoxSelectedID.ReadOnly = true;
            this.textBoxSelectedID.Size = new System.Drawing.Size(57, 29);
            this.textBoxSelectedID.TabIndex = 5;
            // 
            // dataGridViewCatalog
            // 
            this.dataGridViewCatalog.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewCatalog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCatalog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCatalog.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridViewCatalog.Location = new System.Drawing.Point(3, 34);
            this.dataGridViewCatalog.Name = "dataGridViewCatalog";
            this.dataGridViewCatalog.ReadOnly = true;
            this.dataGridViewCatalog.Size = new System.Drawing.Size(1154, 417);
            this.dataGridViewCatalog.TabIndex = 2;
            this.dataGridViewCatalog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCatalog_CellContentClick);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.booksToolStripMenuItem,
            this.authorsToolStripMenuItem,
            this.publishingHousesToolStripMenuItem,
            this.membersToolStripMenuItem,
            this.genresToolStripMenuItem,
            this.typesToolStripMenuItem,
            this.addToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(3, 3);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1157, 29);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // booksToolStripMenuItem
            // 
            this.booksToolStripMenuItem.Name = "booksToolStripMenuItem";
            this.booksToolStripMenuItem.Size = new System.Drawing.Size(64, 25);
            this.booksToolStripMenuItem.Text = "Books";
            this.booksToolStripMenuItem.Click += new System.EventHandler(this.booksToolStripMenuItem_Click);
            // 
            // authorsToolStripMenuItem
            // 
            this.authorsToolStripMenuItem.Name = "authorsToolStripMenuItem";
            this.authorsToolStripMenuItem.Size = new System.Drawing.Size(77, 25);
            this.authorsToolStripMenuItem.Text = "Authors";
            this.authorsToolStripMenuItem.Click += new System.EventHandler(this.authorsToolStripMenuItem_Click);
            // 
            // publishingHousesToolStripMenuItem
            // 
            this.publishingHousesToolStripMenuItem.Name = "publishingHousesToolStripMenuItem";
            this.publishingHousesToolStripMenuItem.Size = new System.Drawing.Size(148, 25);
            this.publishingHousesToolStripMenuItem.Text = "Publishing houses";
            this.publishingHousesToolStripMenuItem.Click += new System.EventHandler(this.publishingHousesToolStripMenuItem_Click);
            // 
            // membersToolStripMenuItem
            // 
            this.membersToolStripMenuItem.Name = "membersToolStripMenuItem";
            this.membersToolStripMenuItem.Size = new System.Drawing.Size(88, 25);
            this.membersToolStripMenuItem.Text = "Members";
            this.membersToolStripMenuItem.Click += new System.EventHandler(this.membersToolStripMenuItem_Click);
            // 
            // genresToolStripMenuItem
            // 
            this.genresToolStripMenuItem.Name = "genresToolStripMenuItem";
            this.genresToolStripMenuItem.Size = new System.Drawing.Size(71, 25);
            this.genresToolStripMenuItem.Text = "Genres";
            this.genresToolStripMenuItem.Click += new System.EventHandler(this.genresToolStripMenuItem_Click);
            // 
            // typesToolStripMenuItem
            // 
            this.typesToolStripMenuItem.Name = "typesToolStripMenuItem";
            this.typesToolStripMenuItem.Size = new System.Drawing.Size(61, 25);
            this.typesToolStripMenuItem.Text = "Types";
            this.typesToolStripMenuItem.Click += new System.EventHandler(this.typesToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genreToolStripMenuItem,
            this.typeToolStripMenuItem,
            this.authorToolStripMenuItem,
            this.publishingHouseToolStripMenuItem,
            this.bookToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(50, 25);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // genreToolStripMenuItem
            // 
            this.genreToolStripMenuItem.Name = "genreToolStripMenuItem";
            this.genreToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.genreToolStripMenuItem.Text = "Genre";
            this.genreToolStripMenuItem.Click += new System.EventHandler(this.genreToolStripMenuItem_Click);
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.typeToolStripMenuItem.Text = "Type";
            this.typeToolStripMenuItem.Click += new System.EventHandler(this.typeToolStripMenuItem_Click);
            // 
            // authorToolStripMenuItem
            // 
            this.authorToolStripMenuItem.Name = "authorToolStripMenuItem";
            this.authorToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.authorToolStripMenuItem.Text = "Author";
            this.authorToolStripMenuItem.Click += new System.EventHandler(this.authorToolStripMenuItem_Click);
            // 
            // publishingHouseToolStripMenuItem
            // 
            this.publishingHouseToolStripMenuItem.Name = "publishingHouseToolStripMenuItem";
            this.publishingHouseToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.publishingHouseToolStripMenuItem.Text = "Publishing house";
            this.publishingHouseToolStripMenuItem.Click += new System.EventHandler(this.publishingHouseToolStripMenuItem_Click);
            // 
            // bookToolStripMenuItem
            // 
            this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
            this.bookToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.bookToolStripMenuItem.Text = "Book";
            this.bookToolStripMenuItem.Click += new System.EventHandler(this.bookToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewMyBooks);
            this.tabPage2.Controls.Add(this.menuStrip1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1163, 509);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "My books";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewMyBooks
            // 
            this.dataGridViewMyBooks.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewMyBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewMyBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMyBooks.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridViewMyBooks.Location = new System.Drawing.Point(3, 34);
            this.dataGridViewMyBooks.Name = "dataGridViewMyBooks";
            this.dataGridViewMyBooks.ReadOnly = true;
            this.dataGridViewMyBooks.Size = new System.Drawing.Size(1003, 417);
            this.dataGridViewMyBooks.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1157, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(46, 25);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonReturned);
            this.tabPage3.Controls.Add(this.textBoxOnHands);
            this.tabPage3.Controls.Add(this.dataGridViewOnHands);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1163, 509);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Books on hands";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonReturned
            // 
            this.buttonReturned.Location = new System.Drawing.Point(71, 469);
            this.buttonReturned.Name = "buttonReturned";
            this.buttonReturned.Size = new System.Drawing.Size(161, 29);
            this.buttonReturned.TabIndex = 8;
            this.buttonReturned.Text = "Returned";
            this.buttonReturned.UseVisualStyleBackColor = true;
            this.buttonReturned.Click += new System.EventHandler(this.buttonReturned_Click);
            // 
            // textBoxOnHands
            // 
            this.textBoxOnHands.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxOnHands.Location = new System.Drawing.Point(8, 469);
            this.textBoxOnHands.Name = "textBoxOnHands";
            this.textBoxOnHands.ReadOnly = true;
            this.textBoxOnHands.Size = new System.Drawing.Size(57, 29);
            this.textBoxOnHands.TabIndex = 6;
            // 
            // dataGridViewOnHands
            // 
            this.dataGridViewOnHands.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewOnHands.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewOnHands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOnHands.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridViewOnHands.Location = new System.Drawing.Point(4, 3);
            this.dataGridViewOnHands.Name = "dataGridViewOnHands";
            this.dataGridViewOnHands.ReadOnly = true;
            this.dataGridViewOnHands.Size = new System.Drawing.Size(1154, 460);
            this.dataGridViewOnHands.TabIndex = 3;
            this.dataGridViewOnHands.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOnHands_CellContentClick);
            // 
            // LibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 555);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LibraryForm";
            this.Text = "Form2";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCatalog)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyBooks)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOnHands)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView dataGridViewMyBooks;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewCatalog;
        private System.Windows.Forms.ToolStripMenuItem booksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publishingHousesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem membersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publishingHouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typesToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxSelectedID;
        private System.Windows.Forms.Button buttonTakeIt;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBoxOnHands;
        private System.Windows.Forms.DataGridView dataGridViewOnHands;
        private System.Windows.Forms.Button buttonReturned;
        private System.Windows.Forms.Button buttonUpdateOrAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
    }
}