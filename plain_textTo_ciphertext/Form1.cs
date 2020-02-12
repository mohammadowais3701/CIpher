using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plain_textTo_ciphertext
{
    public partial class Form1 : Form
    {
        List<Char> alphabet = new List<char>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Char c1 = 'A';
            int n,k=32,y;
            for (int i = 0; i <=25; i++)
            {
                alphabet.Add(c1);
                c1++;
            }
            if (comboBox1.Text == "Shift")
            { 
                if (plaintxtbox.Text != "")
                {
                    try
                    {
                        string str = (keytxt.Text).ToUpper();
                        n = alphabet.IndexOf(str[0]);
                  
                        
                        ciphrtxt.Text = "";
                        String txt = plaintxtbox.Text.ToUpper();
                        for (int i = 0; i < (plaintxtbox.Text).Length; i++)
                        {
                            
                          
                            if (Convert.ToInt16(txt[i]) != 32)
                            {
                                y = alphabet.IndexOf(txt[i]);
                                k = (y + n) % 26;
                                ciphrtxt.Text += alphabet[k];
                            }
                            else
                            {
                                ciphrtxt.Text += " ";
                            }
                            //  if (!((k >= 65 && k <= 90) || (k >= 97 && k <= 122)))
                          

                          
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong");
                    }
                }
                else if (ciphrtxt.Text != "")
                {
                    try
                    {
                        string str = (keytxt.Text).ToUpper();
                         n = alphabet.IndexOf((str[0]));
                       
                        plaintxtbox.Text = "";
                        String txt = ciphrtxt.Text.ToUpper();
                        for (int i = 0; i < (ciphrtxt.Text).Length; i++)
                        {
                            if (Convert.ToInt16(txt[i]) != 32)
                            {
                                y = alphabet.IndexOf(txt[i]);
                                k = (y - n);
                                if (k < 0)
                                    k = (26 + k) % 26;
                                //   if (!((k >= 65 && k <= 90) || (k >= 97 && k <= 122)))
                                // k = k + 25;
                                plaintxtbox.Text += alphabet[k];
                            }
                            else
                            {
                                plaintxtbox.Text += " ";
                            }
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong");
                    }
                }
                else
                {
                    MessageBox.Show("No Text is available");

                }
        }
            else if (comboBox1.Text == "Vigenere")
            {
                int keyindex;
                if (plaintxtbox.Text != "")
                {
                    try
                    {
                        string str = (keytxt.Text).ToUpper();
                        
                  

                        ciphrtxt.Text = "";
                        String txt = plaintxtbox.Text.ToUpper();
                        for (int i = 0; i < (plaintxtbox.Text).Length; i++)
                        {
                            if (Convert.ToInt16(txt[i]) != 32)
                            {
                                keyindex = i % (str.Length);
                                n = alphabet.IndexOf(str[keyindex]);
                                y = alphabet.IndexOf(txt[i]);
                                k = (y + n) % 26;
                                ciphrtxt.Text += alphabet[k];
                                //  if (!((k >= 65 && k <= 90) || (k >= 97 && k <= 122)))
                            }
                            else
                            {
                                ciphrtxt.Text += " ";
                            }
                            
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong");
                    }
                }
                else if (ciphrtxt.Text != "")
                {
                    try
                    {
                        string str = (keytxt.Text).ToUpper();
                       

                        plaintxtbox.Text = "";
                        String txt = ciphrtxt.Text.ToUpper();
                        for (int i = 0; i < (ciphrtxt.Text).Length; i++)
                        {
                            if (Convert.ToInt16(txt[i]) != 32)
                            {
                                keyindex = i % (str.Length);
                                n = alphabet.IndexOf(str[keyindex]);
                                y = alphabet.IndexOf(txt[i]);
                                k = (y - n);
                                if (k < 0)
                                    k = (26 + k) % 26;

                                plaintxtbox.Text += alphabet[k];
                            }
                            {
                                plaintxtbox.Text += " ";
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong");
                    }
                }


            }
            else if (comboBox1.Text == "PlayFair")
            {


                int keyindex,len,l=-1;
                if (plaintxtbox.Text != "")
                {
                    try
                    {
                        string str = (keytxt.Text).ToUpper();
                     
                        //   char[] playfair = new char[25];
                        List<char> playfair = new List<char>();
                        char ch = 'A';
                        len = str.Length;

                        char[,] playfairs = new char[5, 5];
                        for(int i = 0; i < len; i++)
                        {
                            if (Convert.ToInt16(str[i]) != 32 && str[i]!='J')
                            {
                                if (!playfair.Contains(str[i]))
                                {
                                    playfair.Add(str[i]);
                                    l++;
                                }
                            }
                        }
                   
                        for(int j = 0; j < 26; j++)
                        {
                           
                            if (!playfair.Contains(ch) && ch!='J')
                            {
                                playfair.Add(ch);
                            }
                          
                            ch++;
                        }
                        /* for(int i = 0; i < playfair.Count; i++)
                         {
                             MessageBox.Show(Convert.ToString(playfair[i]));
                         }*/
                        int h = 0,w1=0,x1=0,w2=0,x2=0,c=0;
                
                        for(int i = 0; i < 5; i++)
                        {
                            for(int j = 0; j < 5; j++)
                            {
                                playfairs[i, j] = playfair[h];
                              
                                h++;
                            }
                        }
                        
                        ciphrtxt.Text = "";
                        string pt = plaintxtbox.Text.Replace(" ", "");
                        pt=pt.Replace("J", "K");
                        for ( int i = 0; i < pt.Length; i++)
                        {
                            if(!((pt[i]>='A' && pt[i]<='Z')|| (pt[i]>='a' && pt[i] <= 'z')))
                            {
                                pt = pt.Remove(i);
                               
                            }
                        }
                        if (pt.Length % 2 != 0)
                        {
                            pt += 'X';
                        }
                        
                        for (int index = 0; index < pt.Length; index ++)
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                for (int j = 0; j < 5; j++)
                                {
                                    if (pt[index] == playfairs[i, j])
                                    {
                                        if (c == 0)
                                        {
                                            w1 = i;
                                            x1 = j;
                                        }
                                        else if (c == 1)
                                        {
                                            w2 = i;
                                            x2 = j;
                                        }
                                        c++;
                                    }

                                }
                            }
                            if (c == 2)
                            {
                                c = 0;
                                if (w1 == w2)
                                {
                                    x2++;
                                    x1++;
                                    ciphrtxt.Text += playfairs[w1, (x1 % 5)];
                                          ciphrtxt.Text += playfairs[w1, (x2 % 5)];
                                }
                                else if (x1 == x2)
                                {
                                    w1++;
                                    w2++;
                                    ciphrtxt.Text += playfairs[(w1 % 5), x1];
                                     ciphrtxt.Text += playfairs[(w2%5), x1];

                                }
                                else
                                {
                                    ciphrtxt.Text += playfairs[w1, x2];
                                    ciphrtxt.Text += playfairs[w2,x1];
                                }
                            }
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong");
                    }
                }


            }
            else if(comboBox1.Text=="") { MessageBox.Show("Select Algorithm "); }
            }
        }
    
}
