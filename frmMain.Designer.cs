namespace BlueStacksConfigEditer
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드
        
        private void InitializeComponent()
        {
            this.cboChannelname = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstView = new System.Windows.Forms.ListView();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtpkgname = new System.Windows.Forms.TextBox();
            this.txtfeatureIconUrl = new System.Windows.Forms.TextBox();
            this.txticonUrl = new System.Windows.Forms.TextBox();
            this.txtbannerUrl = new System.Windows.Forms.TextBox();
            this.txtchannelIds = new System.Windows.Forms.TextBox();
            this.txtrank = new System.Windows.Forms.TextBox();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.txtrating = new System.Windows.Forms.TextBox();
            this.txtpkgver = new System.Windows.Forms.TextBox();
            this.txtapkUrl = new System.Windows.Forms.TextBox();
            this.txtscreenshots = new System.Windows.Forms.TextBox();
            this.txtdeveloper = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cboChange = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboChannelname
            // 
            this.cboChannelname.FormattingEnabled = true;
            this.cboChannelname.Location = new System.Drawing.Point(86, 14);
            this.cboChannelname.Name = "cboChannelname";
            this.cboChannelname.Size = new System.Drawing.Size(231, 20);
            this.cboChannelname.TabIndex = 0;
            this.cboChannelname.SelectedIndexChanged += new System.EventHandler(this.cboChannelname_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "게임 종류 :";
            // 
            // lstView
            // 
            this.lstView.Location = new System.Drawing.Point(15, 40);
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(1194, 292);
            this.lstView.TabIndex = 2;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lstView_DrawColumnHeader);
            this.lstView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lstView_DrawItem);
            this.lstView.SelectedIndexChanged += new System.EventHandler(this.lstView_SelectedIndexChanged);
            this.lstView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstView_ColumnClick);
            this.lstView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lstView_DrawSubItem);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(86, 345);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(1122, 21);
            this.txtTitle.TabIndex = 3;
            // 
            // txtpkgname
            // 
            this.txtpkgname.Location = new System.Drawing.Point(86, 375);
            this.txtpkgname.Name = "txtpkgname";
            this.txtpkgname.Size = new System.Drawing.Size(1122, 21);
            this.txtpkgname.TabIndex = 4;
            // 
            // txtfeatureIconUrl
            // 
            this.txtfeatureIconUrl.Location = new System.Drawing.Point(86, 405);
            this.txtfeatureIconUrl.Name = "txtfeatureIconUrl";
            this.txtfeatureIconUrl.Size = new System.Drawing.Size(1122, 21);
            this.txtfeatureIconUrl.TabIndex = 5;
            // 
            // txticonUrl
            // 
            this.txticonUrl.Location = new System.Drawing.Point(86, 435);
            this.txticonUrl.Name = "txticonUrl";
            this.txticonUrl.Size = new System.Drawing.Size(1122, 21);
            this.txticonUrl.TabIndex = 6;
            // 
            // txtbannerUrl
            // 
            this.txtbannerUrl.Location = new System.Drawing.Point(86, 465);
            this.txtbannerUrl.Name = "txtbannerUrl";
            this.txtbannerUrl.Size = new System.Drawing.Size(1122, 21);
            this.txtbannerUrl.TabIndex = 7;
            // 
            // txtchannelIds
            // 
            this.txtchannelIds.Location = new System.Drawing.Point(217, 495);
            this.txtchannelIds.Name = "txtchannelIds";
            this.txtchannelIds.Size = new System.Drawing.Size(990, 21);
            this.txtchannelIds.TabIndex = 8;
            // 
            // txtrank
            // 
            this.txtrank.Location = new System.Drawing.Point(86, 525);
            this.txtrank.Name = "txtrank";
            this.txtrank.Size = new System.Drawing.Size(1122, 21);
            this.txtrank.TabIndex = 9;
            // 
            // txtdescription
            // 
            this.txtdescription.Location = new System.Drawing.Point(86, 555);
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(1122, 21);
            this.txtdescription.TabIndex = 10;
            // 
            // txtrating
            // 
            this.txtrating.Location = new System.Drawing.Point(86, 585);
            this.txtrating.Name = "txtrating";
            this.txtrating.Size = new System.Drawing.Size(1122, 21);
            this.txtrating.TabIndex = 11;
            // 
            // txtpkgver
            // 
            this.txtpkgver.Location = new System.Drawing.Point(86, 615);
            this.txtpkgver.Name = "txtpkgver";
            this.txtpkgver.Size = new System.Drawing.Size(1122, 21);
            this.txtpkgver.TabIndex = 12;
            // 
            // txtapkUrl
            // 
            this.txtapkUrl.Location = new System.Drawing.Point(86, 645);
            this.txtapkUrl.Name = "txtapkUrl";
            this.txtapkUrl.Size = new System.Drawing.Size(1122, 21);
            this.txtapkUrl.TabIndex = 13;
            // 
            // txtscreenshots
            // 
            this.txtscreenshots.Location = new System.Drawing.Point(86, 675);
            this.txtscreenshots.Name = "txtscreenshots";
            this.txtscreenshots.Size = new System.Drawing.Size(1122, 21);
            this.txtscreenshots.TabIndex = 14;
            // 
            // txtdeveloper
            // 
            this.txtdeveloper.Location = new System.Drawing.Point(86, 705);
            this.txtdeveloper.Name = "txtdeveloper";
            this.txtdeveloper.Size = new System.Drawing.Size(1122, 21);
            this.txtdeveloper.TabIndex = 15;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(86, 732);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "신규 게임 추가";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(371, 732);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(135, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "선택 게임 삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(1080, 732);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(129, 23);
            this.btnConfirm.TabIndex = 18;
            this.btnConfirm.Text = "적용(환경파일 생성)";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 349);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "타이틀";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "패키지명";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 411);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "미사용";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 441);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "아이콘 url";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 471);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "배너 url";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 501);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "채널";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 531);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "임의 순위";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 559);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 26;
            this.label9.Text = "설명";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 590);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "구글앱 순위";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 620);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 12);
            this.label11.TabIndex = 28;
            this.label11.Text = "패키지 버전";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 651);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 29;
            this.label12.Text = "앱파일 url";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 681);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 12);
            this.label13.TabIndex = 30;
            this.label13.Text = "screenshots";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 709);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 31;
            this.label14.Text = "개발자";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(221, 732);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(135, 23);
            this.btnUpdate.TabIndex = 32;
            this.btnUpdate.Text = "선택 게임 수정";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cboChange
            // 
            this.cboChange.FormattingEnabled = true;
            this.cboChange.Location = new System.Drawing.Point(85, 496);
            this.cboChange.Name = "cboChange";
            this.cboChange.Size = new System.Drawing.Size(121, 20);
            this.cboChange.TabIndex = 33;
            this.cboChange.SelectedIndexChanged += new System.EventHandler(this.cboChange_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 763);
            this.Controls.Add(this.cboChange);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtdeveloper);
            this.Controls.Add(this.txtscreenshots);
            this.Controls.Add(this.txtapkUrl);
            this.Controls.Add(this.txtpkgver);
            this.Controls.Add(this.txtrating);
            this.Controls.Add(this.txtdescription);
            this.Controls.Add(this.txtrank);
            this.Controls.Add(this.txtchannelIds);
            this.Controls.Add(this.txtbannerUrl);
            this.Controls.Add(this.txticonUrl);
            this.Controls.Add(this.txtfeatureIconUrl);
            this.Controls.Add(this.txtpkgname);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lstView);
            this.Controls.Add(this.cboChannelname);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlueStacks";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtpkgname;
        private System.Windows.Forms.TextBox txtfeatureIconUrl;
        private System.Windows.Forms.TextBox txticonUrl;
        private System.Windows.Forms.TextBox txtbannerUrl;
        private System.Windows.Forms.TextBox txtchannelIds;
        private System.Windows.Forms.TextBox txtrank;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.TextBox txtrating;
        private System.Windows.Forms.TextBox txtpkgver;
        private System.Windows.Forms.TextBox txtapkUrl;
        private System.Windows.Forms.TextBox txtscreenshots;
        private System.Windows.Forms.TextBox txtdeveloper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboChannelname;
        private System.Windows.Forms.ListView lstView;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ComboBox cboChange;
    }
}

