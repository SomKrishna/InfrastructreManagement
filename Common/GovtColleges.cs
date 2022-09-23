using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfrastructureManagement.Common
{
    public static class GovtColleges
    {
        public static readonly List<College> GovtITIsCollegesList =
                                                               new List<College>
                                                               {
                                                                   new College{Id=1, Name="ITI Talcher,Anugul"},
                                                                   new College{Id=2, Name="ITI Boudh"},
                                                                   new College{Id=3, Name="ITI Purusottampur,Ganjam"},
                                                                   new College{Id=4, Name="ITI Shergarh,Ganjam"},
                                                                   new College{Id=5, Name="ITI Jajpur"},
                                                                   new College{Id=6, Name="Special ITI for PWD Jatni,Khurda"},
                                                                   new College{Id=7, Name="ITI Malkangiri"},
                                                                   new College{Id=8, Name="ITI Nayagarh"},
                                                                   new College{Id=9, Name="ITI Gajabahal,Bissamcuttack,Raygada"},
                                                                   new College{Id=10, Name="ITI Rayagada"},
                                                                   new College{Id=11, Name="ITI Rourkela"},
                                                                   new College{Id=12, Name="ITI Balasore"},
                                                                   new College{Id=13, Name="ITI Bheden,Bargarh"},
                                                                   new College{Id=14, Name="ITI Bolangir"},
                                                                   new College{Id=15, Name=" Madhusudan ITI,Cuttack"},
                                                                   new College{Id=16, Name="ITI Barkote,Deogarh"},
                                                                   new College{Id=17, Name="ITI Dhenkanal"},
                                                                   new College{Id=18, Name="ITI Jharsuguda"},
                                                                   new College{Id=19, Name="SIPT Pattamundai,Kendrapada"},
                                                                   new College{Id=20, Name="ITI Barbil,Keonjhar"},
                                                                   new College{Id=21, Name="ITI Kotpad,Koraput"},
                                                                   new College{Id=22, Name="ITI Laxmipur,Koraput"},
                                                                   new College{Id=23, Name=" ITI Matheli,Malkanagiri"},
                                                                   new College{Id=24, Name="TTI Takatpur,Mayurbhanj"},
                                                                   new College{Id=25, Name="ITI Raighar,Nabrangpur"},
                                                                   new College{Id=26, Name=" ITI Khariar,Nuapada"},
                                                                   new College{Id=27, Name="ITI Khariar Road,Nuapada"},
                                                                   new College{Id=28, Name="ITI Puri"},
                                                                   new College{Id=29, Name="ITI Bargarh"},
                                                                   new College{Id=30, Name="ITI Cuttack"},
                                                                   new College{Id=31, Name="ITI Gumma,Gajapati"},
                                                                   new College{Id=32, Name="ITI Berhampur,Ganjam"},
                                                                   new College{Id=33, Name="ITI Anandapur,Keonjhar"},
                                                                   new College{Id=34, Name="ITI Patangi,Koraput"},
                                                                   new College{Id=35, Name="ITI Chandahandi,Nabrangpur"},
                                                                   new College{Id=36, Name="ITI Umarkote,Nabrangpur"},
                                                                   new College{Id=37, Name="ITI Hirakud,Sambalpur"},
                                                                   new College{Id=38, Name="ITI Sonepur"},
                                                                   new College{Id=39, Name="ITI Bhubaneswar,Khurda"},
                                                                   new College{Id=40, Name="Gandhamardana ITI,Bolangir"},
                                                                   new College{Id=41, Name="ITI Raigada,Gajapati"},
                                                                   new College{Id=42, Name="Gopabandhu ITI Ambaguda,Koraput"},
                                                                   new College{Id=43, Name="Purna Chandra ITI Baripada,Mayurbhanj"},
                                                                   new College{Id=44, Name="ITI Rasanpur,Sambalpur"},
                                                                   new College{Id=45, Name="ITI Chandragiri,Gajapati"},
                                                                   new College{Id=46, Name="ITI Chhatrapur,Ganjam"},
                                                                   new College{Id=47, Name="ITI Hinjilcut,Ganjam"},
                                                                   new College{Id=48, Name="ITI Bhawanipatna,Kalahandi"},
                                                                   new College{Id=49, Name="ITI Phulbani,Kandhamal"}
                                                               };
        public static readonly List<College> GovtGovtPolytechnicsCollegesList =
                                                               new List<College>
                                                               {
                                                                   new College{Id=1, Name="Government Polytechnic,Angul"},
                                                                   new College{Id=2, Name="Government Polytechnic,Balasore"},
                                                                   new College{Id=3, Name="Government Polytechnic,Bargarh"},
                                                                   new College{Id=4, Name="Government Polytechnic,Bhadrak"},
                                                                   new College{Id=5, Name="Government Polytechnic,Bolangir" },
                                                                   new College{Id=6, Name="Government Polytechnic,Boudh"},
                                                                   new College{Id=7, Name="Bhubanananda Orissa School Of Engineering,Cuttack"},
                                                                   new College{Id=8, Name="Government Polytechnic,Devgarh"},
                                                                   new College{Id=9, Name="Government Polytechnic,Dhenkanal"},
                                                                   new College{Id=10, Name="Government Polytechnic,Gajapati"},
                                                                   new College{Id=11, Name="Uma Charan Patnaik Engineering School,Berhampur"},
                                                                   new College{Id=12, Name="Government Polytechnic,Berhampur"},
                                                                   new College{Id=13, Name=" Government Polytechnic,Jagatsinghpur"},
                                                                   new College{Id=14, Name="Government Polytechnic,Jajpur"},
                                                                   new College{Id=15, Name="Government Polytechnic,Kendrapara"},
                                                                   new College{Id=16, Name="Government Polytechnic,Koraput"},
                                                                   new College{Id=17, Name="Government Polytechnic,Mayurbhanj"},
                                                                   new College{Id=18, Name="Govt Polytechnic,Nabarangapur"},
                                                                   new College{Id=19, Name="Government Polytechnic,Nayagarh"},
                                                                   new College{Id=20, Name="Government Polytechnic,Nuapada"},
                                                                   new College{Id=21, Name="Biju Patnaik Institute Of Technology,Puri"},
                                                                   new College{Id=22, Name="Utkal Gourav Madhusudan Institute Of Technology,Rayagada"},
                                                                   new College{Id=23, Name="Government Polytechnic,Sambalpur"},
                                                                   new College{Id=24, Name="Government Polytechnic,Sonepur"},
                                                                   new College{Id=25, Name="Skdav Govt. Polytechnic,Rourkela,Sundergarh"},
                                                                   new College{Id=26, Name="Utkalmani Gopabandhu Institute Of Engineering,Rourkela,Sundergarh"},
                                                                   new College{Id=27, Name="Orissa School Of Mining Engineering,Keonjhar"},
                                                                   new College{Id=28, Name="Government Polytechnic,Kandhamal"},
                                                                   new College{Id=29, Name="Jharsuguda Engineering School,Jharsuguda"},
                                                                   new College{Id=30, Name="Government Polytechnic,Malkanagiri"},
                                                                   new College{Id=31, Name="Indira Gandhi Institute Of Technology,Sarang"},
                                                                   new College{Id=32, Name="Government Polytechnic,Kalahandi"},
                                                                   new College{Id=33, Name="Government Polytechnic,Bhubaneswar"}
                                                               };
    }
}