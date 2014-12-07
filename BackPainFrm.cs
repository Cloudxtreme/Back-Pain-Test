using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Back_Pain_Test
{
    public partial class BackPainFrm : Form
    {
        Dictionary<string, string> rs2073711_AA_pos = null;

        const int RESULT_PROB_TRUE = 2;
        const int RESULT_TRUE = 1;
        const int RESULT_FALSE = 0;
        const int RESULT_NA = -1;

        public BackPainFrm()
        {
            InitializeComponent();
        }

        private void BackPainFrm_Load(object sender, EventArgs e)
        {
            rs2073711_AA_pos = new Dictionary<string, string>();
            rs2073711_AA_pos.Add("rs28666660", "G");
            rs2073711_AA_pos.Add("rs7175765", "G");
            rs2073711_AA_pos.Add("rs563082", "T");
            rs2073711_AA_pos.Add("rs514319", "A");
            rs2073711_AA_pos.Add("rs12593770", "G");
            rs2073711_AA_pos.Add("rs16953514", "T");
            rs2073711_AA_pos.Add("rs640005", "A");
            rs2073711_AA_pos.Add("rs16948024", "G");
            rs2073711_AA_pos.Add("rs673931", "A");
            rs2073711_AA_pos.Add("rs11071799", "C");
            rs2073711_AA_pos.Add("rs2733386", "GA");
            rs2073711_AA_pos.Add("rs16948046", "T");
            rs2073711_AA_pos.Add("rs8036775", "G");
            rs2073711_AA_pos.Add("rs547818", "A");
            rs2073711_AA_pos.Add("rs633275", "G");
            rs2073711_AA_pos.Add("rs16948101", "A");
            rs2073711_AA_pos.Add("rs627101", "AC");
            rs2073711_AA_pos.Add("rs16948108", "A");
            rs2073711_AA_pos.Add("rs2593699", "C");
            rs2073711_AA_pos.Add("rs4777488", "T");
            rs2073711_AA_pos.Add("rs8029243", "G");
            rs2073711_AA_pos.Add("rs10519272", "A");
            rs2073711_AA_pos.Add("rs4777499", "T");
            rs2073711_AA_pos.Add("rs11633399", "AC");
            rs2073711_AA_pos.Add("rs11071803", "G");
            rs2073711_AA_pos.Add("rs16948170", "C");
            rs2073711_AA_pos.Add("rs11631564", "G");
            rs2073711_AA_pos.Add("rs16948182", "T");
            rs2073711_AA_pos.Add("rs3751534", "G");
            rs2073711_AA_pos.Add("rs11858605", "C");
            rs2073711_AA_pos.Add("rs7402386", "G");
            rs2073711_AA_pos.Add("rs7173216", "C");
            rs2073711_AA_pos.Add("rs10162671", "G");
            rs2073711_AA_pos.Add("rs7402511", "C");
            rs2073711_AA_pos.Add("rs7495961", "C");
            rs2073711_AA_pos.Add("rs6494489", "CT");
            rs2073711_AA_pos.Add("rs7403071", "A");
            rs2073711_AA_pos.Add("rs10851739", "A");
            rs2073711_AA_pos.Add("rs1008917", "C");
            rs2073711_AA_pos.Add("rs7174486", "A");
            rs2073711_AA_pos.Add("rs4777601", "T");
            rs2073711_AA_pos.Add("rs4777602", "A");
            rs2073711_AA_pos.Add("rs28704836", "G");
            rs2073711_AA_pos.Add("rs17208301", "C");
            rs2073711_AA_pos.Add("rs8036568", "T");
            rs2073711_AA_pos.Add("rs1872592", "A");
            rs2073711_AA_pos.Add("rs3743046", "C");
            rs2073711_AA_pos.Add("rs4777615", "T");
            rs2073711_AA_pos.Add("rs2414858", "A");
            rs2073711_AA_pos.Add("rs1719288", "T");
            rs2073711_AA_pos.Add("rs1522747", "T");
            rs2073711_AA_pos.Add("rs1352093", "G");
            rs2073711_AA_pos.Add("rs832882", "G");
            rs2073711_AA_pos.Add("rs832884", "C");
            rs2073711_AA_pos.Add("rs16948311", "G");
            rs2073711_AA_pos.Add("rs832886", "C");
            rs2073711_AA_pos.Add("rs2010875", "C");
            rs2073711_AA_pos.Add("rs1043690", "A");
            rs2073711_AA_pos.Add("rs1043697", "C");
            rs2073711_AA_pos.Add("rs3183338", "T");
            rs2073711_AA_pos.Add("rs1719271", "A");
            rs2073711_AA_pos.Add("rs2200490", "C");
            rs2073711_AA_pos.Add("rs1628955", "C");
            rs2073711_AA_pos.Add("rs936867", "AG");
            rs2073711_AA_pos.Add("rs1631677", "A");
            rs2073711_AA_pos.Add("rs12437824", "AG");
            rs2073711_AA_pos.Add("rs832878", "A");
            rs2073711_AA_pos.Add("rs1471834", "A");
            rs2073711_AA_pos.Add("rs2056497", "C");
            rs2073711_AA_pos.Add("rs4287512", "CT");
            rs2073711_AA_pos.Add("rs7168200", "TG");
            rs2073711_AA_pos.Add("rs12438783", "G");
            rs2073711_AA_pos.Add("rs12442603", "G");
            rs2073711_AA_pos.Add("rs7178748", "C");
            rs2073711_AA_pos.Add("rs28406502", "T");
            rs2073711_AA_pos.Add("rs34988193", "A");
            rs2073711_AA_pos.Add("rs2414865", "C");
            rs2073711_AA_pos.Add("rs2277539", "C");
            rs2073711_AA_pos.Add("rs6494503", "GA");
            rs2073711_AA_pos.Add("rs4776654", "A");
            rs2073711_AA_pos.Add("rs16948431", "T");
            rs2073711_AA_pos.Add("rs1554524", "G");
            rs2073711_AA_pos.Add("rs16948440", "T");
            rs2073711_AA_pos.Add("rs7322", "TC");
            rs2073711_AA_pos.Add("rs17229765", "GA");
            rs2073711_AA_pos.Add("rs2280555", "GT");
            rs2073711_AA_pos.Add("rs4346160", "CT");
            rs2073711_AA_pos.Add("rs4316701", "G");
            rs2073711_AA_pos.Add("rs11633597", "GA");
            rs2073711_AA_pos.Add("rs8042506", "GA");
            rs2073711_AA_pos.Add("rs16948457", "G");
            rs2073711_AA_pos.Add("rs11635570", "GA");
            rs2073711_AA_pos.Add("rs34636936", "C");
            rs2073711_AA_pos.Add("rs4776660", "A");
            rs2073711_AA_pos.Add("rs8035428", "TC");
            rs2073711_AA_pos.Add("rs8024697", "TG");
            rs2073711_AA_pos.Add("rs8029145", "A");
            rs2073711_AA_pos.Add("rs2946662", "AC");
            rs2073711_AA_pos.Add("rs4776661", "T");
            rs2073711_AA_pos.Add("rs2946656", "C");
            rs2073711_AA_pos.Add("rs7175761", "T");
            rs2073711_AA_pos.Add("rs2946653", "T");
            rs2073711_AA_pos.Add("rs8031050", "G");
            rs2073711_AA_pos.Add("rs2919351", "T");
            rs2073711_AA_pos.Add("rs2919352", "A");
            rs2073711_AA_pos.Add("rs1046482", "T");
            rs2073711_AA_pos.Add("rs2232762", "G");
            rs2073711_AA_pos.Add("rs2232753", "A");
            rs2073711_AA_pos.Add("rs2241858", "A");
            rs2073711_AA_pos.Add("rs9630429", "A");
            rs2073711_AA_pos.Add("rs4238400", "C");
            rs2073711_AA_pos.Add("rs12440107", "A");
            rs2073711_AA_pos.Add("rs12904843", "G");
            rs2073711_AA_pos.Add("rs4776664", "A");
            rs2073711_AA_pos.Add("rs2946650", "G");
            rs2073711_AA_pos.Add("rs12916225", "C");
            rs2073711_AA_pos.Add("rs11855621", "G");
            rs2073711_AA_pos.Add("rs11852900", "A");
            rs2073711_AA_pos.Add("rs17805328", "C");
            rs2073711_AA_pos.Add("rs4776670", "C");
            rs2073711_AA_pos.Add("rs7175110", "T");
            rs2073711_AA_pos.Add("rs11071828", "C");
            rs2073711_AA_pos.Add("rs2946672", "T");
            rs2073711_AA_pos.Add("rs12595310", "C");
            rs2073711_AA_pos.Add("rs2414878", "G");
            rs2073711_AA_pos.Add("rs4776258", "G");
            rs2073711_AA_pos.Add("rs12903989", "C");
            rs2073711_AA_pos.Add("rs938951", "A");
            rs2073711_AA_pos.Add("rs938952", "T");
            rs2073711_AA_pos.Add("rs2679117", "C");
            rs2073711_AA_pos.Add("rs34908405", "T");
            rs2073711_AA_pos.Add("rs2679118", "C");
            rs2073711_AA_pos.Add("rs756625", "G");
            rs2073711_AA_pos.Add("rs11071829", "C");
            rs2073711_AA_pos.Add("rs2073711", "A");
            rs2073711_AA_pos.Add("rs11856834", "C");
            rs2073711_AA_pos.Add("rs2585034", "C");
            rs2073711_AA_pos.Add("rs2681038", "A");
            rs2073711_AA_pos.Add("rs2585033", "C");
            rs2073711_AA_pos.Add("rs2019185", "G");
            rs2073711_AA_pos.Add("rs16948565", "T");
            rs2073711_AA_pos.Add("rs1442795", "C");
            rs2073711_AA_pos.Add("rs1561888", "G");
            rs2073711_AA_pos.Add("rs8023487", "G");
            rs2073711_AA_pos.Add("rs8023869", "C");
            rs2073711_AA_pos.Add("rs17805775", "C");
            rs2073711_AA_pos.Add("rs3759849", "C");
            rs2073711_AA_pos.Add("rs11639264", "T");
            rs2073711_AA_pos.Add("rs11071830", "T");
            rs2073711_AA_pos.Add("rs920686", "G");
            rs2073711_AA_pos.Add("rs755115", "C");
            rs2073711_AA_pos.Add("rs11632307", "G");
            rs2073711_AA_pos.Add("rs920688", "C");
            rs2073711_AA_pos.Add("rs16948596", "G");
            rs2073711_AA_pos.Add("rs4415968", "G");
            rs2073711_AA_pos.Add("rs894494", "C");
            rs2073711_AA_pos.Add("rs8024728", "G");
            rs2073711_AA_pos.Add("rs11071835", "T");
            rs2073711_AA_pos.Add("rs665287", "A");
            rs2073711_AA_pos.Add("rs7175829", "C");
            rs2073711_AA_pos.Add("rs556177", "C");
            rs2073711_AA_pos.Add("rs680552", "T");
            rs2073711_AA_pos.Add("rs681856", "A");
            rs2073711_AA_pos.Add("rs11071838", "A");
            rs2073711_AA_pos.Add("rs626163", "A");
            rs2073711_AA_pos.Add("rs525514", "T");
            rs2073711_AA_pos.Add("rs7162046", "A");
            rs2073711_AA_pos.Add("rs639812", "G");
            rs2073711_AA_pos.Add("rs11853777", "A");
            rs2073711_AA_pos.Add("rs12907128", "A");
            rs2073711_AA_pos.Add("rs894491", "A");
            rs2073711_AA_pos.Add("rs581427", "T");
            rs2073711_AA_pos.Add("rs603439", "A");
            rs2073711_AA_pos.Add("rs8031618", "G");
            rs2073711_AA_pos.Add("rs575749", "G");
            rs2073711_AA_pos.Add("rs1442796", "T");
            rs2073711_AA_pos.Add("rs678113", "T");
            rs2073711_AA_pos.Add("rs578708", "C");
            rs2073711_AA_pos.Add("rs602192", "C");
            rs2073711_AA_pos.Add("rs6494518", "A");
            rs2073711_AA_pos.Add("rs7182756", "G");
            rs2073711_AA_pos.Add("rs2280345", "A");
            rs2073711_AA_pos.Add("rs2292933", "T");
            rs2073711_AA_pos.Add("rs11071841", "G");
            rs2073711_AA_pos.Add("rs2277582", "A");
            rs2073711_AA_pos.Add("rs1550027", "A");
            rs2073711_AA_pos.Add("rs12442757", "T");
            rs2073711_AA_pos.Add("rs668278", "A");
            rs2073711_AA_pos.Add("rs588842", "G");
            rs2073711_AA_pos.Add("rs736923", "A");
            rs2073711_AA_pos.Add("rs591980", "AG");
            rs2073711_AA_pos.Add("rs593647", "GA");
            rs2073711_AA_pos.Add("rs612401", "G");
            rs2073711_AA_pos.Add("rs7171289", "C");
            rs2073711_AA_pos.Add("rs2289045", "G");
            rs2073711_AA_pos.Add("rs652931", "CT");
            rs2073711_AA_pos.Add("rs892650", "C");
            rs2073711_AA_pos.Add("rs11009", "C");
            rs2073711_AA_pos.Add("rs7163482", "TC");
            rs2073711_AA_pos.Add("rs12595213", "C");
            rs2073711_AA_pos.Add("rs3825891", "T");
            rs2073711_AA_pos.Add("rs7174627", "G");
            rs2073711_AA_pos.Add("rs352457", "G");
            rs2073711_AA_pos.Add("rs409987", "G");
            rs2073711_AA_pos.Add("rs1865421", "A");
            rs2073711_AA_pos.Add("rs11071846", "GA");
            rs2073711_AA_pos.Add("rs352480", "T");
            rs2073711_AA_pos.Add("rs3784448", "C");
            rs2073711_AA_pos.Add("rs9635366", "G");
            rs2073711_AA_pos.Add("rs352476", "TC");
            rs2073711_AA_pos.Add("rs8039978", "C");
            rs2073711_AA_pos.Add("rs7164489", "A");
            rs2073711_AA_pos.Add("rs430515", "G");
            rs2073711_AA_pos.Add("rs2456015", "T");
            rs2073711_AA_pos.Add("rs395300", "A");
            rs2073711_AA_pos.Add("rs189518", "T");
            rs2073711_AA_pos.Add("rs2456009", "CA");
            rs2073711_AA_pos.Add("rs1003104", "G");
            rs2073711_AA_pos.Add("rs7164255", "C");
            rs2073711_AA_pos.Add("rs10519294", "A");
            rs2073711_AA_pos.Add("rs16948825", "A");
            rs2073711_AA_pos.Add("rs2279854", "A");
            rs2073711_AA_pos.Add("rs12333", "C");
            rs2073711_AA_pos.Add("rs3743168", "T");
            rs2073711_AA_pos.Add("rs3743169", "G");
            rs2073711_AA_pos.Add("rs11484", "G");
            rs2073711_AA_pos.Add("rs11635626", "A");
            rs2073711_AA_pos.Add("rs2899708", "G");
            rs2073711_AA_pos.Add("rs16948867", "A");
            rs2073711_AA_pos.Add("rs12906196", "CT");
            rs2073711_AA_pos.Add("rs4366668", "AG");
            rs2073711_AA_pos.Add("rs870022", "C");
            rs2073711_AA_pos.Add("rs3743171", "A");
            rs2073711_AA_pos.Add("rs34363823", "G");
            rs2073711_AA_pos.Add("rs35984752", "G");
            rs2073711_AA_pos.Add("rs12917564", "G");
            rs2073711_AA_pos.Add("rs16948886", "C");
            rs2073711_AA_pos.Add("rs16948889", "A");
            rs2073711_AA_pos.Add("rs1211944", "C");
            rs2073711_AA_pos.Add("rs12910810", "T");
            rs2073711_AA_pos.Add("rs16948916", "T");
            rs2073711_AA_pos.Add("rs8035639", "TC");
            rs2073711_AA_pos.Add("rs905733", "T");
            rs2073711_AA_pos.Add("rs16948924", "G");
            rs2073711_AA_pos.Add("rs8027260", "T");
            rs2073711_AA_pos.Add("rs8030562", "CT");
            rs2073711_AA_pos.Add("rs11858075", "C");
            rs2073711_AA_pos.Add("rs8028238", "C");
            rs2073711_AA_pos.Add("rs1435125", "A");
            rs2073711_AA_pos.Add("rs11071848", "T");
            rs2073711_AA_pos.Add("rs17810074", "C");
            rs2073711_AA_pos.Add("rs7162611", "T");
            rs2073711_AA_pos.Add("rs934542", "G");
            rs2073711_AA_pos.Add("rs10519303", "T");
            rs2073711_AA_pos.Add("rs7180542", "C");
            rs2073711_AA_pos.Add("rs6494537", "TC");
            rs2073711_AA_pos.Add("rs2572217", "C");
            rs2073711_AA_pos.Add("rs2727098", "T");
            rs2073711_AA_pos.Add("rs721151", "C");
            rs2073711_AA_pos.Add("rs2727102", "C");
            rs2073711_AA_pos.Add("rs17816071", "T");
            rs2073711_AA_pos.Add("rs2572209", "C");
            rs2073711_AA_pos.Add("rs8035725", "G");
            rs2073711_AA_pos.Add("rs16949046", "A");
            rs2073711_AA_pos.Add("rs8027781", "CA");
            rs2073711_AA_pos.Add("rs2727087", "C");
            rs2073711_AA_pos.Add("rs2727089", "C");
            rs2073711_AA_pos.Add("rs2660632", "T");
            rs2073711_AA_pos.Add("rs2899713", "C");
            rs2073711_AA_pos.Add("rs10851750", "G");
            rs2073711_AA_pos.Add("rs9806220", "G");
            rs2073711_AA_pos.Add("rs2660619", "G");
            rs2073711_AA_pos.Add("rs11634367", "A");
            rs2073711_AA_pos.Add("rs11071852", "T");
            rs2073711_AA_pos.Add("rs12593305", "G");
            rs2073711_AA_pos.Add("rs12594238", "T");
            rs2073711_AA_pos.Add("rs2414891", "A");
            rs2073711_AA_pos.Add("rs12904203", "A");
            rs2073711_AA_pos.Add("rs4530073", "G");
            rs2073711_AA_pos.Add("rs4514623", "T");
            rs2073711_AA_pos.Add("rs11854887", "A");
            rs2073711_AA_pos.Add("rs11634482", "A");
            rs2073711_AA_pos.Add("rs11637538", "A");
            rs2073711_AA_pos.Add("rs1063697", "T");
            rs2073711_AA_pos.Add("rs16949087", "C");
            rs2073711_AA_pos.Add("rs11071853", "C");
            rs2073711_AA_pos.Add("rs11638122", "A");
            rs2073711_AA_pos.Add("rs16949091", "A");
            rs2073711_AA_pos.Add("rs333542", "A");
            rs2073711_AA_pos.Add("rs3803414", "G");
            rs2073711_AA_pos.Add("rs16949100", "T");
            rs2073711_AA_pos.Add("rs11637551", "G");
            rs2073711_AA_pos.Add("rs875948", "A");
            rs2073711_AA_pos.Add("rs11635501", "C");
            rs2073711_AA_pos.Add("rs10519311", "C");
            rs2073711_AA_pos.Add("rs10400879", "G");
            rs2073711_AA_pos.Add("rs16949128", "T");


        }

        public byte[] Zip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }

        public byte[] Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return mso.ToArray();
            }
        }

        public void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                int world_average_age=80;
                int user_avg_age = world_average_age;

                int avg_risk = checkIBD(dialog.FileName, rs2073711_AA_pos, "rs2073711", "15", "AA");

                switch (avg_risk)
                {
                    case RESULT_NA:
                        MessageBox.Show("Insufficient data.");
                        break;
                    case RESULT_TRUE:
                        MessageBox.Show("You have normal risk of lumbar disc disease.");
                        break;
                    case RESULT_PROB_TRUE:
                        MessageBox.Show("You may have normal risk of lumbar disc disease.");
                        break;
                    case RESULT_FALSE:
                        MessageBox.Show("You have high risk of lumbar disc disease.");
                        break;
                }                
            }
        }

        private int checkIBD(string file,  Dictionary<string, string> ibd_gt_ref, string rsid, string chr, string target_gt)
        {
            List<string> match = new List<string>();
            string text = getAutosomalText(file);

            StringReader reader = new StringReader(text);
            string line = null;
            string[] data=null;
            bool is_match = true;
            int error_count = 0;
            int allowed_errors = ibd_gt_ref.Count * 4 / 100;
            //StringBuilder stmp = new StringBuilder();
            while((line=reader.ReadLine())!=null)
            {
                if (line.StartsWith("#") || line.StartsWith("RSID") || line.StartsWith("rsid"))
                    continue;
                line = line.Replace("\"", "").Replace("\t",",");
                data=line.Split(new char[]{','});
                if (data.Length == 5)
                    data[3] = data[3] + data[4];               

                if(data[1]==chr)
                {
                    //stmp.Append(line);
                    //stmp.Append("\r\n");

                    if (data[0] == rsid)
                    {
                        if (data[3] == target_gt)
                            return RESULT_TRUE;
                        else
                            return RESULT_FALSE;
                    }

                    if(ibd_gt_ref.ContainsKey(data[0]))
                    {
                        if (ibd_gt_ref[data[0]].Length == 1)
                        {
                            if (ibd_gt_ref[data[0]] == data[3][0].ToString() || ibd_gt_ref[data[0]] == data[3][1].ToString())
                                match.Add(data[0]);
                            else
                            {
                                if (data[3].IndexOf("-") != -1 || data[3].IndexOf("0") != -1 || data[3].IndexOf("?") != -1)
                                    continue;

                                error_count++;
                                if (error_count >= allowed_errors)
                                {
                                    is_match = false;
                                    break;
                                }
                                else
                                    match.Add(data[0]);
                            }
                        }
                        else if (ibd_gt_ref[data[0]].Length == 2)
                        {
                            if (ibd_gt_ref[data[0]][0].ToString() == data[3][0].ToString() ||
                                ibd_gt_ref[data[0]][0].ToString() == data[3][1].ToString() ||
                                ibd_gt_ref[data[0]][1].ToString() == data[3][0].ToString() ||
                                ibd_gt_ref[data[0]][1].ToString() == data[3][1].ToString())
                                    match.Add(data[0]);
                            else
                            {
                                if (data[3].IndexOf("-") != -1 || data[3].IndexOf("0") != -1 || data[3].IndexOf("?") != -1)
                                    continue;

                                error_count++;
                                if (error_count >= allowed_errors)
                                {
                                    is_match = false;
                                    break;
                                }
                                else
                                    match.Add(data[0]);
                            }
                        }
                        else
                        {
                            if (data[3].IndexOf("-") != -1 || data[3].IndexOf("0") != -1 || data[3].IndexOf("?") != -1)
                                continue;

                            error_count++;
                            if (error_count >= allowed_errors)
                            {
                                is_match = false;
                                break;
                            }
                            else
                                match.Add(data[0]);
                        }
                    }
                }
            }

            //File.WriteAllText(@"D:\Temp\" + Path.GetFileName(file) + ".7", stmp.ToString());

            if (is_match)
            {
                if (match.Count >= ibd_gt_ref.Keys.Count*0.9)
                    return RESULT_TRUE;
                else if (match.Count >= ibd_gt_ref.Keys.Count * 0.5)
                    return RESULT_PROB_TRUE;
                else
                    return RESULT_NA;
            }
            else
            {
                return RESULT_FALSE;
            }
        }

        private string getAutosomalText(string file)
        {
            string text = null;

            if (file.EndsWith(".gz"))
            {
                StringReader reader = new StringReader(Encoding.UTF8.GetString(Unzip(File.ReadAllBytes(file))));
                text = reader.ReadToEnd();
                reader.Close();

            }
            else if (file.EndsWith(".zip"))
            {
                using (var fs = new MemoryStream(File.ReadAllBytes(file)))
                using (var zf = new ZipFile(fs))
                {
                    var ze = zf[0];
                    if (ze == null)
                    {
                        throw new ArgumentException("file not found in Zip");
                    }
                    using (var s = zf.GetInputStream(ze))
                    {
                        using (StreamReader sr = new StreamReader(s))
                        {
                            text = sr.ReadToEnd();
                        }
                    }
                }
            }
            else
                text = File.ReadAllText(file);
            return text;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.y-str.org/");
        }
    }
}
