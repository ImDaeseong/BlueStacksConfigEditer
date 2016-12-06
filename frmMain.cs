using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace BlueStacksConfigEditer
{
    public partial class frmMain : Form
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr CopyFile(string lpExistingFileName, string lpNewFileName, int bFailIfExists);

        private bool bLoadForm = false;

        private List<Channelname> lstChannelname = new List<Channelname>();
        private List<ChannelApps> lstChannelApps = new List<ChannelApps>();

        void ClearLoadData()
        {
            lstChannelname.Clear();
            lstChannelApps.Clear();
        }

        public Channelname GetChannelName(string ID)
        {
            int nIndex = 0;
            for (int i = 0; i < lstChannelname.Count; i++)
            {
                if (ID == lstChannelname[i].ID)
                {
                    nIndex = i;
                    break;
                }
            }
            return lstChannelname[nIndex];
        }

        public string GetChannelID(string name)
        {
            string sID = "";
            for (int i = 0; i < lstChannelname.Count; i++)
            {
                if (name == lstChannelname[i].NAME)
                {
                    sID = lstChannelname[i].ID;
                    break;
                }
            }
            return sID;
        }

        public ChannelApps GetChannelApps(string title, string pkgname)
        {
            int nIndex = 0;
            for (int i = 0; i < lstChannelApps.Count; i++)
            {
                if (title == lstChannelApps[i].TITLE && pkgname == lstChannelApps[i].PKGNAME)
                {
                    nIndex = i;
                    break;
                }
            }
            return lstChannelApps[nIndex];
        }

        public bool DeleteChannelApps(string title, string pkgname)
        {
            bool bDelete = false;
            for (int i = 0; i < lstChannelApps.Count; i++)
            {
                if (title == lstChannelApps[i].TITLE && pkgname == lstChannelApps[i].PKGNAME)
                {
                    bDelete = true;
                    lstChannelApps.RemoveAt(i);
                    break;
                }
            }
            return bDelete;
        }

        public bool FindChannelApps(string title, string pkgname)
        {
            bool bFindApp = false;
            for (int i = 0; i < lstChannelApps.Count; i++)
            {
                if (title == lstChannelApps[i].TITLE && pkgname == lstChannelApps[i].PKGNAME)
                {
                    bFindApp = true;
                    break;
                }
            }
            return bFindApp;
        }

        void LoadChannelName(string strPath)
        {
            string strSplit = "";
            using (StreamReader sr = new StreamReader(strPath, Encoding.GetEncoding("euc-kr")))
            {
                strSplit = sr.ReadToEnd();
                sr.Close();
            }
            if (strSplit == "") return;

            string strParser = "";
            string[] blocks = strSplit.Split('{', '}');
            for (int i = 0; i < blocks.Length; i++)
            {
                strParser = blocks[i].Trim();
                if (strParser.Length == 1 || strParser.Length == 0)
                    continue;

                Channelname item = new Channelname();
                string[] rows = strParser.Split(',');
                foreach (string line in rows)
                {
                    string[] value = line.Split(':');
                    string Name = value[0].Replace("\"", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
                    string key = value[1].Replace("\"", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();

                    if (Name == "id") item.ID = key;
                    if (Name == "name") item.NAME = key;
                    if (Name == "type") item.TYPE = key;
                    if (Name == "key") item.KEY = key;
                }
                lstChannelname.Add(item);
            }
        }

        void LoadChannelAppName(string strPath)
        {
            string strSplit = File.ReadAllText(strPath);
            if (strSplit == "") return;

            string strParser = "";
            string[] blocks = strSplit.Split('{', '}');
            for (int i = 0; i < blocks.Length; i++)
            {
                strParser = blocks[i].Trim();

                if (strParser.Length == 1 || strParser.Length == 0)
                    continue;

                ChannelApps item = new ChannelApps();
                using (StringReader sr = new StringReader(strParser))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        int indexOf = line.IndexOf(':');
                        string sChkName = line.Substring(0, indexOf);
                        string sChkkey = line.Substring(indexOf + 1, line.Length - indexOf - 1);

                        string Name = sChkName.Replace("\"", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
                        string key = sChkkey.Replace("\"", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();

                        if (key.LastIndexOf(',') != -1)
                            key = key.Remove(key.LastIndexOf(','));

                        if (Name == "title") item.TITLE = key;
                        if (Name == "pkgName") item.PKGNAME = key;
                        if (Name == "featureIconUrl") item.FEATUREICONURL = key;
                        if (Name == "iconUrl") item.ICONURL = key;
                        if (Name == "bannerUrl") item.BANNERURL = key;

                        if (Name == "channelIds")
                        {
                            item.CHANNELIDS = key.Replace("[", "").Replace("]", "").Trim();
                        }

                        if (Name == "screenshots")
                        {
                            item.SCREENSHOTS = key.Replace("[", "").Replace("]", "").Trim();
                        }

                        if (Name == "rank") item.RANK = key;
                        if (Name == "description") item.DESCRIPTION = key;
                        if (Name == "rating") item.RATING = key;
                        if (Name == "pkgver") item.PKGVER = key;
                        if (Name == "apkUrl") item.APKURL = key;
                        if (Name == "developer") item.DEVELOPER = key;
                    }
                }
                lstChannelApps.Add(item);
            }
        }

        void InitLoadData()
        {
            string sChannelname = string.Format("{0}\\channel_names.json", Application.StartupPath);
            string sChannelApps = string.Format("{0}\\channel_apps.json", Application.StartupPath);

            if (File.Exists(sChannelname)) LoadChannelName(sChannelname);
            if (File.Exists(sChannelApps)) LoadChannelAppName(sChannelApps);


            string sIndexID = "";
            if (lstChannelname.Count > 0)
                cboChange.Items.Add("채널 변경");

            for (int i = 0; i < lstChannelname.Count; i++)
            {
                if (i == 0)
                    sIndexID = lstChannelname[i].ID;

                string sItem = lstChannelname[i].NAME.Trim();
                cboChannelname.Items.Add(sItem);

                cboChange.Items.Add(sItem);
            }
            if (lstChannelname.Count > 0)
            {
                cboChannelname.SelectedIndex = 0;
                cboChange.SelectedIndex = 0;
            }


            lstView.View = View.Details;
            lstView.GridLines = true;
            lstView.FullRowSelect = true;
            lstView.HeaderStyle = ColumnHeaderStyle.Clickable;
            lstView.CheckBoxes = true;
            lstView.OwnerDraw = true;

            lstView.Columns.Add("", 25, HorizontalAlignment.Left);
            lstView.Columns.Add("타이틀", 160, HorizontalAlignment.Left);
            lstView.Columns.Add("패키지명", 150, HorizontalAlignment.Left);
            lstView.Columns.Add("featureIconUrl", 0, HorizontalAlignment.Left);
            lstView.Columns.Add("아이콘 url", 100, HorizontalAlignment.Left);
            lstView.Columns.Add("배너 url", 100, HorizontalAlignment.Left);
            lstView.Columns.Add("채널", 70, HorizontalAlignment.Left);
            lstView.Columns.Add("임의 순위", 70, HorizontalAlignment.Left);
            lstView.Columns.Add("설명", 100, HorizontalAlignment.Left);
            lstView.Columns.Add("구글앱 순위", 80, HorizontalAlignment.Left);
            lstView.Columns.Add("패키지 버전", 80, HorizontalAlignment.Left);
            lstView.Columns.Add("앱파일 url", 160, HorizontalAlignment.Left);
            lstView.Columns.Add("screenshots", 0, HorizontalAlignment.Left);
            lstView.Columns.Add("개발자", 100, HorizontalAlignment.Left);

            for (int i = 0; i < lstChannelApps.Count; i++)
            {
                if (sIndexID == lstChannelApps[i].CHANNELIDS)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = "";
                    item.SubItems.Add(lstChannelApps[i].TITLE);
                    item.SubItems.Add(lstChannelApps[i].PKGNAME);
                    item.SubItems.Add(lstChannelApps[i].FEATUREICONURL);
                    item.SubItems.Add(lstChannelApps[i].ICONURL);
                    item.SubItems.Add(lstChannelApps[i].BANNERURL);
                    item.SubItems.Add(lstChannelApps[i].CHANNELIDS);
                    item.SubItems.Add(lstChannelApps[i].RANK);
                    item.SubItems.Add(lstChannelApps[i].DESCRIPTION);
                    item.SubItems.Add(lstChannelApps[i].RATING);
                    item.SubItems.Add(lstChannelApps[i].PKGVER);
                    item.SubItems.Add(lstChannelApps[i].APKURL);
                    item.SubItems.Add(lstChannelApps[i].SCREENSHOTS);
                    item.SubItems.Add(lstChannelApps[i].DEVELOPER);
                    lstView.Items.Add(item);

                    //ListViewItem item = new ListViewItem(new string[] { 
                    //    lstChannelApps[i].TITLE, 
                    //    lstChannelApps[i].PKGNAME,
                    //    lstChannelApps[i].FEATUREICONURL, 
                    //    lstChannelApps[i].ICONURL,
                    //    lstChannelApps[i].BANNERURL, 
                    //    lstChannelApps[i].CHANNELIDS,
                    //    lstChannelApps[i].RANK, 
                    //    lstChannelApps[i].DESCRIPTION,
                    //    lstChannelApps[i].RATING,
                    //    lstChannelApps[i].PKGVER,
                    //    lstChannelApps[i].APKURL,
                    //    lstChannelApps[i].SCREENSHOTS,
                    //    lstChannelApps[i].DEVELOPER});
                    //lstView.Items.Add(item);
                }
            }


            //로딩시 백업
            string sChannelAppsBackup = string.Format("{0}\\Backup", Application.StartupPath);
            if (!Directory.Exists(sChannelAppsBackup))
                Directory.CreateDirectory(sChannelAppsBackup);
            CopyFile(sChannelApps, sChannelAppsBackup + "\\channel_apps.json", 1);
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitLoadData();

            txtfeatureIconUrl.Enabled = false;
            txtchannelIds.Enabled = false;

            bLoadForm = true;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearLoadData();
        }

        private void cboChannelname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bLoadForm) return;

            string sIndexID = "";
            if (cboChannelname.SelectedIndex >= 0)
            {
                sIndexID = GetChannelID(cboChannelname.SelectedItem.ToString());

                lstView.Items.Clear();
                txtTitle.Text = "";
                txtpkgname.Text = "";
                txtfeatureIconUrl.Text = "";
                txticonUrl.Text = "";
                txtbannerUrl.Text = "";
                txtchannelIds.Text = "";
                txtrank.Text = "";
                txtdescription.Text = "";
                txtrating.Text = "";
                txtpkgver.Text = "";
                txtapkUrl.Text = "";
                txtscreenshots.Text = "";
                txtdeveloper.Text = "";

                for (int i = 0; i < lstChannelApps.Count; i++)
                {
                    if (sIndexID == lstChannelApps[i].CHANNELIDS)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = "";
                        item.SubItems.Add(lstChannelApps[i].TITLE);
                        item.SubItems.Add(lstChannelApps[i].PKGNAME);
                        item.SubItems.Add(lstChannelApps[i].FEATUREICONURL);
                        item.SubItems.Add(lstChannelApps[i].ICONURL);
                        item.SubItems.Add(lstChannelApps[i].BANNERURL);
                        item.SubItems.Add(lstChannelApps[i].CHANNELIDS);
                        item.SubItems.Add(lstChannelApps[i].RANK);
                        item.SubItems.Add(lstChannelApps[i].DESCRIPTION);
                        item.SubItems.Add(lstChannelApps[i].RATING);
                        item.SubItems.Add(lstChannelApps[i].PKGVER);
                        item.SubItems.Add(lstChannelApps[i].APKURL);
                        item.SubItems.Add(lstChannelApps[i].SCREENSHOTS);
                        item.SubItems.Add(lstChannelApps[i].DEVELOPER);
                        lstView.Items.Add(item);
                    }
                }
            }
        }

        private void cboChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sIndexID = "";
            if (cboChange.SelectedIndex >= 0)
            {
                sIndexID = GetChannelID(cboChange.SelectedItem.ToString());
                txtchannelIds.Text = sIndexID;
            }
        }

        private void lstView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count > 0)
            {
                string title = lstView.SelectedItems[0].SubItems[1].Text.ToString();
                string pkgname = lstView.SelectedItems[0].SubItems[2].Text.ToString();
                string featureIconUrl = lstView.SelectedItems[0].SubItems[3].Text.ToString();
                string iconUrl = lstView.SelectedItems[0].SubItems[4].Text.ToString();
                string bannerUrl = lstView.SelectedItems[0].SubItems[5].Text.ToString();
                string channelIds = lstView.SelectedItems[0].SubItems[6].Text.ToString();
                string rank = lstView.SelectedItems[0].SubItems[7].Text.ToString();
                string description = lstView.SelectedItems[0].SubItems[8].Text.ToString();
                string rating = lstView.SelectedItems[0].SubItems[9].Text.ToString();
                string pkgver = lstView.SelectedItems[0].SubItems[10].Text.ToString();
                string apkUrl = lstView.SelectedItems[0].SubItems[11].Text.ToString();
                string screenshots = lstView.SelectedItems[0].SubItems[12].Text.ToString();
                string developer = lstView.SelectedItems[0].SubItems[13].Text.ToString();

                txtTitle.Text = title;
                txtpkgname.Text = pkgname;
                txtfeatureIconUrl.Text = featureIconUrl;
                txticonUrl.Text = iconUrl;
                txtbannerUrl.Text = bannerUrl;
                txtchannelIds.Text = channelIds;
                txtrank.Text = rank;
                txtdescription.Text = description;
                txtrating.Text = rating;
                txtpkgver.Text = pkgver;
                txtapkUrl.Text = apkUrl;
                txtscreenshots.Text = screenshots;
                txtdeveloper.Text = developer;
            }
            else
            {
                txtTitle.Text = "";
                txtpkgname.Text = "";
                txtfeatureIconUrl.Text = "";
                txticonUrl.Text = "";
                txtbannerUrl.Text = "";
                txtchannelIds.Text = "";
                txtrank.Text = "";
                txtdescription.Text = "";
                txtrating.Text = "";
                txtpkgver.Text = "";
                txtapkUrl.Text = "";
                txtscreenshots.Text = "";
                txtdeveloper.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sIndexID = "";
            sIndexID = GetChannelID(cboChannelname.SelectedItem.ToString());
            if (sIndexID == "") return;
            else txtchannelIds.Text = sIndexID;

            if (txtTitle.Text == "") return;
            if (txtpkgname.Text == "") return;
          
            if (!FindChannelApps(txtTitle.Text, txtpkgname.Text))
            {
                ChannelApps item = new ChannelApps();
                item.TITLE = txtTitle.Text;
                item.PKGNAME = txtpkgname.Text;
                item.FEATUREICONURL = txticonUrl.Text;
                item.ICONURL = txticonUrl.Text;
                item.BANNERURL = txtbannerUrl.Text;
                item.CHANNELIDS = txtchannelIds.Text;
                item.RANK = txtrank.Text;
                item.DESCRIPTION = txtdescription.Text;
                item.RATING = txtrating.Text;
                item.PKGVER = txtpkgver.Text;
                item.APKURL = txtapkUrl.Text;
                item.SCREENSHOTS = txtscreenshots.Text;
                item.DEVELOPER = txtdeveloper.Text;
                lstChannelApps.Add(item);

                cboChannelname_SelectedIndexChanged(null, null);
            }
            else
            {
                MessageBox.Show("이미 등록된 게임입니다.");
            }

            txtTitle.Text = "";
            txtpkgname.Text = "";
            txtfeatureIconUrl.Text = "";
            txticonUrl.Text = "";
            txtbannerUrl.Text = "";
            txtchannelIds.Text = "";
            txtrank.Text = "";
            txtdescription.Text = "";
            txtrating.Text = "";
            txtpkgver.Text = "";
            txtapkUrl.Text = "";
            txtscreenshots.Text = "";
            txtdeveloper.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count > 0)
            {
                string title = lstView.SelectedItems[0].SubItems[1].Text.ToString();
                string pkgname = lstView.SelectedItems[0].SubItems[2].Text.ToString();
                string featureIconUrl = lstView.SelectedItems[0].SubItems[3].Text.ToString();
                string iconUrl = lstView.SelectedItems[0].SubItems[4].Text.ToString();
                string bannerUrl = lstView.SelectedItems[0].SubItems[5].Text.ToString();
                string channelIds = lstView.SelectedItems[0].SubItems[6].Text.ToString();
                string rank = lstView.SelectedItems[0].SubItems[7].Text.ToString();
                string description = lstView.SelectedItems[0].SubItems[8].Text.ToString();
                string rating = lstView.SelectedItems[0].SubItems[9].Text.ToString();
                string pkgver = lstView.SelectedItems[0].SubItems[10].Text.ToString();
                string apkUrl = lstView.SelectedItems[0].SubItems[11].Text.ToString();
                string screenshots = lstView.SelectedItems[0].SubItems[12].Text.ToString();
                string developer = lstView.SelectedItems[0].SubItems[13].Text.ToString();

                ChannelApps item = GetChannelApps(title, pkgname);
                item.TITLE = txtTitle.Text;
                item.PKGNAME = txtpkgname.Text;
                item.FEATUREICONURL = txticonUrl.Text;
                item.ICONURL = txticonUrl.Text;
                item.BANNERURL = txtbannerUrl.Text;
                item.CHANNELIDS = txtchannelIds.Text;
                item.RANK = txtrank.Text;
                item.DESCRIPTION = txtdescription.Text;
                item.RATING = txtrating.Text;
                item.PKGVER = txtpkgver.Text;
                item.APKURL = txtapkUrl.Text;
                item.SCREENSHOTS = txtscreenshots.Text;
                item.DEVELOPER = txtdeveloper.Text;

                cboChannelname_SelectedIndexChanged(null, null);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool bDelete = false;
            for (int i = lstView.Items.Count - 1; i >= 0; i--)
            {
                if (lstView.Items[i].Checked)
                {
                    string title = lstView.Items[i].SubItems[1].Text.ToString();
                    string pkgname = lstView.Items[i].SubItems[2].Text.ToString();
                    string featureIconUrl = lstView.Items[i].SubItems[3].Text.ToString();
                    string iconUrl = lstView.Items[i].SubItems[4].Text.ToString();
                    string bannerUrl = lstView.Items[i].SubItems[5].Text.ToString();
                    string channelIds = lstView.Items[i].SubItems[6].Text.ToString();
                    string rank = lstView.Items[i].SubItems[7].Text.ToString();
                    string description = lstView.Items[i].SubItems[8].Text.ToString();
                    string rating = lstView.Items[i].SubItems[9].Text.ToString();
                    string pkgver = lstView.Items[i].SubItems[10].Text.ToString();
                    string apkUrl = lstView.Items[i].SubItems[11].Text.ToString();
                    string screenshots = lstView.Items[i].SubItems[12].Text.ToString();
                    string developer = lstView.Items[i].SubItems[13].Text.ToString();

                    lstView.Items.RemoveAt(i);

                    DeleteChannelApps(title, pkgname);

                    bDelete = true;
                }
            }

            if (bDelete) cboChannelname_SelectedIndexChanged(null, null);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (lstChannelApps.Count == 0)
            {
                MessageBox.Show("저장할 내용이 존재하지 않습니다.");
                return;
            }

            string sChannelApps = string.Format("{0}\\channel_apps.json", Application.StartupPath);
            File.Delete(sChannelApps);


            FileStream aFileStream = new FileStream(sChannelApps, FileMode.OpenOrCreate);
            StreamWriter aStreamWriter = new StreamWriter(aFileStream);

            aStreamWriter.Write("[");
            aStreamWriter.WriteLine();

            for (int i = 0; i < lstChannelApps.Count; i++)
            {
                string sCommonStart = " {\r\n";
                string title = string.Format("    \"title\" :\"{0}\",\r\n", lstChannelApps[i].TITLE);
                string pkgname = string.Format("    \"pkgName\" :\"{0}\",\r\n", lstChannelApps[i].PKGNAME);
                string featureIconUrl = string.Format("    \"featureIconUrl\" :\"{0}\",\r\n", lstChannelApps[i].FEATUREICONURL);
                string iconUrl = string.Format("    \"iconUrl\" :\"{0}\",\r\n", lstChannelApps[i].ICONURL);
                string bannerUrl = string.Format("    \"bannerUrl\" :\"{0}\",\r\n", lstChannelApps[i].BANNERURL);
                string channelIds = string.Format("    \"channelIds\" :[\"{0}\"],\r\n", lstChannelApps[i].CHANNELIDS);
                string rank = string.Format("    \"rank\" :\"{0}\",\r\n", lstChannelApps[i].RANK);
                string description = string.Format("    \"description\" :\"{0}\",\r\n", lstChannelApps[i].DESCRIPTION);
                string rating = string.Format("    \"rating\" :\"{0}\",\r\n", lstChannelApps[i].RATING);
                string pkgver = string.Format("    \"pkgver\" :\"{0}\",\r\n", lstChannelApps[i].PKGVER);
                string apkUrl = string.Format("    \"apkUrl\" :\"{0}\",\r\n", lstChannelApps[i].APKURL);
                string screenshots = string.Format("    \"screenshots\" :[\"{0}\"],\r\n", lstChannelApps[i].SCREENSHOTS);
                string developer = string.Format("    \"developer\" :\"{0}\"\r\n", lstChannelApps[i].DEVELOPER);

                string sCommonEnd = "";
                if (i == (lstChannelApps.Count - 1))
                    sCommonEnd = " }";
                else
                    sCommonEnd = " },";

                string sWriteLine = sCommonStart + title + pkgname + featureIconUrl + iconUrl + bannerUrl + channelIds +
                    rank + description + rating + pkgver + apkUrl + screenshots + developer + sCommonEnd;

                aStreamWriter.Write(sWriteLine);
                aStreamWriter.WriteLine();
            }

            aStreamWriter.Write("]");
            aStreamWriter.WriteLine();
            aStreamWriter.Close();

            MessageBox.Show("환경파일 작업이 완료되었습니다.");
        }

        private void InitChkBox()
        {
            for (int i = 0; i < lstView.Items.Count; i++)
                lstView.Items[i].Checked = false;
        }

        private void lstView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics,
                    new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void lstView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lstView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lstView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(lstView.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                lstView.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in lstView.Items)
                    item.Checked = !value;

                lstView.Invalidate();
            }
        }
    }
}





