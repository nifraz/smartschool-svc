using Microsoft.EntityFrameworkCore;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using SmartSchool.Utility.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedMasterData(modelBuilder);
            SeedPersons(modelBuilder);
            SeedUsers(modelBuilder);
            SeedStudents(modelBuilder);
            SeedTeachers(modelBuilder);
            SeedPrincipals(modelBuilder);
            SeedOtherData(modelBuilder);
        }

        private static void SeedMasterData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>().HasData(
                new() { Id = 1, Name = "Western", SinhalaName = "බස්නාහිර", TamilName = "மேற்கு" },
                new() { Id = 2, Name = "Central", SinhalaName = "මධ්‍යම", TamilName = "மத்திய" },
                new() { Id = 3, Name = "Southern", SinhalaName = "දකුණු", TamilName = "தெற்கு" },
                new() { Id = 4, Name = "Northern", SinhalaName = "උතුරු", TamilName = "வடக்கு" },
                new() { Id = 5, Name = "Eastern", SinhalaName = "නැගෙනහිර", TamilName = "கிழக்கு" },
                new() { Id = 6, Name = "North Western", SinhalaName = "වයඹ", TamilName = "வடமேற்கு" },
                new() { Id = 7, Name = "North Central", SinhalaName = "උතුරුමැද", TamilName = "வடமத்திய" },
                new() { Id = 8, Name = "Uva", SinhalaName = "ඌව", TamilName = "ஊவா" },
                new() { Id = 9, Name = "Sabaragamuwa", SinhalaName = "සබරගමුව", TamilName = "சபரகமுவா" }
            );

            modelBuilder.Entity<District>().HasData(
                new() { ProvinceId = 1, Id = 1, Name = "Colombo", SinhalaName = "කොළඹ", TamilName = "கொழும்பு" },
                new() { ProvinceId = 1, Id = 2, Name = "Gampaha", SinhalaName = "ගම්පහ", TamilName = "கம்பகா" },
                new() { ProvinceId = 1, Id = 3, Name = "Kalutara", SinhalaName = "කළුතර", TamilName = "களுத்துறை" },

                new() { ProvinceId = 2, Id = 4, Name = "Kandy", SinhalaName = "මහනුවර", TamilName = "கண்டி" },
                new() { ProvinceId = 2, Id = 5, Name = "Matale", SinhalaName = "මාතලේ", TamilName = "மாத்தளை" },
                new() { ProvinceId = 2, Id = 6, Name = "Nuwara Eliya", SinhalaName = "නුවරඑළිය", TamilName = "நுவரெலியா" },

                new() { ProvinceId = 3, Id = 7, Name = "Galle", SinhalaName = "ගාල්ල", TamilName = "காலி" },
                new() { ProvinceId = 3, Id = 8, Name = "Matara", SinhalaName = "මාතර", TamilName = "மாத்தறை" },
                new() { ProvinceId = 3, Id = 9, Name = "Hambantota", SinhalaName = "හම්බන්තොට", TamilName = "அம்பாந்தோட்டை" },

                new() { ProvinceId = 4, Id = 10, Name = "Jaffna", SinhalaName = "යාපනය", TamilName = "யாழ்ப்பாணம்" },
                new() { ProvinceId = 4, Id = 11, Name = "Mannar", SinhalaName = "මන්නාරම", TamilName = "மன்னார்" },
                new() { ProvinceId = 4, Id = 12, Name = "Vavuniya", SinhalaName = "වවුනියාව", TamilName = "வவுனியா" },
                new() { ProvinceId = 4, Id = 13, Name = "Mullativu", SinhalaName = "මුලතිව්", TamilName = "முல்லைத்தீவு" },
                new() { ProvinceId = 4, Id = 14, Name = "Killinochchi", SinhalaName = "කිලිනොච්චිය", TamilName = "கிளிநொச்சி" },

                new() { ProvinceId = 5, Id = 15, Name = "Batticaloa", SinhalaName = "මඩකලපුව", TamilName = "மட்டக்களப்பு" },
                new() { ProvinceId = 5, Id = 16, Name = "Ampara", SinhalaName = "අම්පාර", TamilName = "அம்பாறை" },
                new() { ProvinceId = 5, Id = 17, Name = "Trincomalee", SinhalaName = "ත්‍රිකුණාමල", TamilName = "திருகோணமலை" },

                new() { ProvinceId = 6, Id = 18, Name = "Kurunegala", SinhalaName = "කුරුණෑගල", TamilName = "குருநாகல்" },
                new() { ProvinceId = 6, Id = 19, Name = "Puttalam", SinhalaName = "පුත්තලම", TamilName = "புத்தளம்" },

                new() { ProvinceId = 7, Id = 20, Name = "Anuradhapura", SinhalaName = "අනුරාධපුර", TamilName = "அனுராதபுரம்" },
                new() { ProvinceId = 7, Id = 21, Name = "Polonnaruwa", SinhalaName = "පොලොන්නරු", TamilName = "பொலநறுவை" },

                new() { ProvinceId = 8, Id = 22, Name = "Badulla", SinhalaName = "බදුල්ල", TamilName = "பதுளை" },
                new() { ProvinceId = 8, Id = 23, Name = "Moneragala", SinhalaName = "මොණරාගල", TamilName = "மொனராகலை" },

                new() { ProvinceId = 9, Id = 24, Name = "Ratnapura", SinhalaName = "රත්නපුර", TamilName = "இரத்தினபுரி" },
                new() { ProvinceId = 9, Id = 25, Name = "Kegalle", SinhalaName = "කෑගල්ල", TamilName = "கேகாலை" }
            );

            modelBuilder.Entity<Zone>().HasData(
                new() { DistrictId = 1, Id = 1, Name = "Colombo Zone", SinhalaName = "කොළඹ කලාපය", TamilName = "கொழும்பு வலயம்" },
                new() { DistrictId = 1, Id = 2, Name = "Homagama Zone", SinhalaName = "හෝමාගම කලාපය", TamilName = "ஹோமாகம வலயம்" },
                new() { DistrictId = 1, Id = 3, Name = "Piliyandala Zone", SinhalaName = "පිළියන්දල කලාපය", TamilName = "பிலியந்தல வலயம்" },
                new() { DistrictId = 1, Id = 4, Name = "Sri Jayawardenapura Zone", SinhalaName = "ශ්‍රී ජයවර්ධනපුර කලාපය", TamilName = "ஸ்ரீ ஜயவர்த்தனபுர வலயம்" },

                new() { DistrictId = 2, Id = 5, Name = "Gampaha Zone", SinhalaName = "ගම්පහ කලාපය", TamilName = "கம்பஹா வலயம்" },
                new() { DistrictId = 2, Id = 6, Name = "Kelaniya Zone", SinhalaName = "කැලණිය කලාපය", TamilName = "கெலனியா வலயம்" },
                new() { DistrictId = 2, Id = 7, Name = "Minuwangoda Zone", SinhalaName = "මිනුවන්ගොඩ කලාපය", TamilName = "மினுவாங்கொட வலயம்" },
                new() { DistrictId = 2, Id = 8, Name = "Negombo Zone", SinhalaName = "නිකඹා කලාපය", TamilName = "நிகம்போ வலயம்" },

                new() { DistrictId = 3, Id = 9, Name = "Horana Zone", SinhalaName = "හොරණ කලාපය", TamilName = "ஹோரனா வலயம்" },
                new() { DistrictId = 3, Id = 10, Name = "Kalutara Zone", SinhalaName = "කළුතර කලාපය", TamilName = "களுத்துறை வலயம்" },
                new() { DistrictId = 3, Id = 11, Name = "Matugama Zone", SinhalaName = "මතුගම කලාපය", TamilName = "மதுகம வலயம்" },

                new() { DistrictId = 4, Id = 12, Name = "Denuwara Zone", SinhalaName = "දෙනුවර කලාපය", TamilName = "தெனுவர வலயம்" },
                new() { DistrictId = 4, Id = 13, Name = "Gampola Zone", SinhalaName = "ගම්පොල කලාපය", TamilName = "கம்பொலா வலயம்" },
                new() { DistrictId = 4, Id = 14, Name = "Kandy Zone", SinhalaName = "මහනුවර කලාපය", TamilName = "கண்டி வலயம்" },
                new() { DistrictId = 4, Id = 15, Name = "Katugastota Zone", SinhalaName = "කටුගස්තොට කලාපය", TamilName = "கட்டுகஸ்தோட்ட வலயம்" },
                new() { DistrictId = 4, Id = 16, Name = "Teldeniya Zone", SinhalaName = "තෙල්දෙණිය කලාපය", TamilName = "தெல்தெணிய வலயம்" },
                new() { DistrictId = 4, Id = 17, Name = "Wattegama Zone", SinhalaName = "වත්තේගම කලාපය", TamilName = "வத்தேகம வலயம்" },

                new() { DistrictId = 5, Id = 18, Name = "Galewala Zone", SinhalaName = "ගලේවල කලාපය", TamilName = "கலேவலா வலயம்" },
                new() { DistrictId = 5, Id = 19, Name = "Matale Zone", SinhalaName = "මාතලේ කලාපය", TamilName = "மாத்தலே வலயம்" },
                new() { DistrictId = 5, Id = 20, Name = "Naula Zone", SinhalaName = "නාවුල කලාපය", TamilName = "நௌலா வலயம்" },
                new() { DistrictId = 5, Id = 21, Name = "Wilgamuwa Zone", SinhalaName = "විල්ගමුව කලාපය", TamilName = "வில்கமுவ வலயம்" },

                new() { DistrictId = 6, Id = 22, Name = "Hanguranketha Zone", SinhalaName = "හඟුරන්කෙත කලාපය", TamilName = "ஹங்குரன்கெத வலயம்" },
                new() { DistrictId = 6, Id = 23, Name = "Hatton Zone", SinhalaName = "හැටන් කලාපය", TamilName = "ஹட்டன் வலயம்" },
                new() { DistrictId = 6, Id = 24, Name = "Kotmale Zone", SinhalaName = "කොත්මලේ කලාපය", TamilName = "கொத்மலே வலயம்" },
                new() { DistrictId = 6, Id = 25, Name = "Nuwara Eliya Zone", SinhalaName = "නුවර එළිය කලාපය", TamilName = "நுவரெலியா வலயம்" },
                new() { DistrictId = 6, Id = 26, Name = "Walapane Zone", SinhalaName = "වලපනේ කලාපය", TamilName = "வலபனே வலயம்" }

            );

            modelBuilder.Entity<Division>().HasData(
                new() { ZoneId = 1, Id = 1, Name = "Borella", SinhalaName = "බොරැල්ල", TamilName = "பொரெல்ல" },
                new() { ZoneId = 1, Id = 2, Name = "Colombo Central", SinhalaName = "කොළඹ මධ්‍යම", TamilName = "மத்திய கொழும்பு" },
                new() { ZoneId = 1, Id = 3, Name = "Colombo North", SinhalaName = "කොළඹ උතුර", TamilName = "வட கொழும்பு" },
                new() { ZoneId = 1, Id = 4, Name = "Colombo South", SinhalaName = "කොළඹ දකුණ", TamilName = "தெற்கு கொழும்பு" },

                new() { ZoneId = 2, Id = 5, Name = "Hanwella", SinhalaName = "හාන්වැල්ල", TamilName = "ஹான்வெல்ல" },
                new() { ZoneId = 2, Id = 6, Name = "Homagama", SinhalaName = "හෝමාගම", TamilName = "ஹோமாகம" },
                new() { ZoneId = 2, Id = 7, Name = "Padukka", SinhalaName = "පඩුක්ක", TamilName = "பதுக்கா" },

                new() { ZoneId = 3, Id = 8, Name = "Dehiwala", SinhalaName = "දෙහිවල", TamilName = "தேஹிவளை" },
                new() { ZoneId = 3, Id = 9, Name = "Kesbewa", SinhalaName = "කැස්බෑව", TamilName = "கெஸ்பேவ" },
                new() { ZoneId = 3, Id = 10, Name = "Moratuwa", SinhalaName = "මොරටුව", TamilName = "மொறட்டுவ" },

                new() { ZoneId = 4, Id = 11, Name = "Kaduwela", SinhalaName = "කඩුවෙල", TamilName = "கடுவெல" },
                new() { ZoneId = 4, Id = 12, Name = "Kolonnawa", SinhalaName = "කොළොන්නාව", TamilName = "கொலன்னாவ" },
                new() { ZoneId = 4, Id = 13, Name = "Maharagama", SinhalaName = "මහරගම", TamilName = "மஹரகம" },
                new() { ZoneId = 4, Id = 14, Name = "Nugegoda", SinhalaName = "නුගේගොඩ", TamilName = "நுகேகொடா" },

                new() { ZoneId = 5, Id = 15, Name = "Attanagalla", SinhalaName = "අත්තනගල්ල", TamilName = "அத்தனகல்ல" },
                new() { ZoneId = 5, Id = 16, Name = "Dompe (Weke)", SinhalaName = "දොම්පේ (වේකේ)", TamilName = "டொம்பே (வேக்கே)" },
                new() { ZoneId = 5, Id = 17, Name = "Gampaha", SinhalaName = "ගම්පහ", TamilName = "கம்பஹா" },

                new() { ZoneId = 6, Id = 18, Name = "Biyagama", SinhalaName = "බියගම", TamilName = "பியகம" },
                new() { ZoneId = 6, Id = 19, Name = "Kelaniya", SinhalaName = "කැලණිය", TamilName = "கெலனியா" },
                new() { ZoneId = 6, Id = 20, Name = "Mahara", SinhalaName = "මහර", TamilName = "மஹர" },
                new() { ZoneId = 6, Id = 21, Name = "Wattala", SinhalaName = "වත්තල", TamilName = "வட்டலா" },

                new() { ZoneId = 7, Id = 22, Name = "Divulapitiya", SinhalaName = "දිවුලපිටිය", TamilName = "திவுலபிட்டிய" },
                new() { ZoneId = 7, Id = 23, Name = "Meerigama", SinhalaName = "මීරිගම", TamilName = "மீரிகம" },
                new() { ZoneId = 7, Id = 24, Name = "Minuwangoda", SinhalaName = "මිනුවන්ගොඩ", TamilName = "மினுவாங்கொட" },

                new() { ZoneId = 8, Id = 25, Name = "Ja-Ela", SinhalaName = "ජා-ඇල", TamilName = "ஜா-எல" },
                new() { ZoneId = 8, Id = 26, Name = "Katana", SinhalaName = "කටාන", TamilName = "கடானா" },
                new() { ZoneId = 8, Id = 27, Name = "Negombo", SinhalaName = "නිකඹො", TamilName = "நிகம்போ" },

                new() { ZoneId = 9, Id = 28, Name = "Bandaragama", SinhalaName = "බණ්ඩාරගම", TamilName = "பண்டாரகம" },
                new() { ZoneId = 9, Id = 29, Name = "Bulathsinhala", SinhalaName = "බුලත්සිංහල", TamilName = "புலத்சிங்கள" },
                new() { ZoneId = 9, Id = 30, Name = "Horana", SinhalaName = "හොරණ", TamilName = "ஹோரனா" },

                new() { ZoneId = 10, Id = 31, Name = "Beruwala", SinhalaName = "බේරුවල", TamilName = "பேருவலா" },
                new() { ZoneId = 10, Id = 32, Name = "Dodangoda", SinhalaName = "දොඩංගොඩ", TamilName = "தொடங்கோட" },
                new() { ZoneId = 10, Id = 33, Name = "Kalutara", SinhalaName = "කළුතර", TamilName = "களுத்துறை" },
                new() { ZoneId = 10, Id = 34, Name = "Panadura", SinhalaName = "පානදුර", TamilName = "பாணதுரை" },

                new() { ZoneId = 11, Id = 35, Name = "Agalawatta", SinhalaName = "අගලවත්ත", TamilName = "அகலவத்த" },
                new() { ZoneId = 11, Id = 36, Name = "Matugama", SinhalaName = "මතුගම", TamilName = "மதுகம" },
                new() { ZoneId = 11, Id = 37, Name = "Palindanuwara", SinhalaName = "පාලිඳනුවර", TamilName = "பாலிந்தனுவர" },
                new() { ZoneId = 11, Id = 38, Name = "Walallawita", SinhalaName = "වලල්ලවිට", TamilName = "வலல்லவிட" },

                new() { ZoneId = 12, Id = 39, Name = "Udunuwara", SinhalaName = "උඩුනුවර", TamilName = "உடுநுவர" },
                new() { ZoneId = 12, Id = 40, Name = "Yatinuwara", SinhalaName = "යටිනුවර", TamilName = "யடிநுவர" },

                new() { ZoneId = 13, Id = 41, Name = "Ganga Ihala Korale", SinhalaName = "ගංගා ඉහල කොරලේ", TamilName = "கங்கா இஹலா கொரலே" },
                new() { ZoneId = 13, Id = 42, Name = "Pasbage Korale", SinhalaName = "පස්බාගේ කොරලේ", TamilName = "பச்பகே கொரலே" },
                new() { ZoneId = 13, Id = 43, Name = "Udapalatha", SinhalaName = "උඩපාලත", TamilName = "உடபாலத" },

                new() { ZoneId = 14, Id = 44, Name = "Gangawata Korale", SinhalaName = "ගංගාවට කොරලේ", TamilName = "கங்காவட்ட கொரலே" },
                new() { ZoneId = 14, Id = 45, Name = "Pathahewaheta", SinhalaName = "පතහේවාහේට", TamilName = "பதஹேவஹேட்ட" },

                new() { ZoneId = 15, Id = 46, Name = "Akurana", SinhalaName = "අකුරණ", TamilName = "அகுரண" },
                new() { ZoneId = 15, Id = 47, Name = "Galagedara", SinhalaName = "ගලගෙදර", TamilName = "கலகெதர" },
                new() { ZoneId = 15, Id = 48, Name = "Harispattuwa", SinhalaName = "හරිස්පත්තුව", TamilName = "ஹரிஸ்பத்துவ" },
                new() { ZoneId = 15, Id = 49, Name = "Hatharaliyadda", SinhalaName = "හතරලියද්ද", TamilName = "ஹதரலியதத" },
                new() { ZoneId = 15, Id = 50, Name = "Poojapitiya", SinhalaName = "පූජාපිටිය", TamilName = "பூஜாபிடிய" },

                new() { ZoneId = 16, Id = 51, Name = "Medadumbara", SinhalaName = "මැදදුම්බර", TamilName = "மெதடும்பர" },
                new() { ZoneId = 16, Id = 52, Name = "Minipe", SinhalaName = "මිනිපේ", TamilName = "மினிபே" },
                new() { ZoneId = 16, Id = 53, Name = "Ududumbara", SinhalaName = "උඩුදුම්බර", TamilName = "உடுடும்பர" },

                new() { ZoneId = 17, Id = 54, Name = "Kundasale", SinhalaName = "කුන්දසාලෙ", TamilName = "குந்தசாலே" },
                new() { ZoneId = 17, Id = 55, Name = "Panvila", SinhalaName = "පන්විල", TamilName = "பன்விலா" },
                new() { ZoneId = 17, Id = 56, Name = "Pathadumbara", SinhalaName = "පාතදුම්බර", TamilName = "பாததும்பர" },

                new() { ZoneId = 18, Id = 57, Name = "Dambulla", SinhalaName = "දඹුල්ල", TamilName = "தம்புள்ள" },
                new() { ZoneId = 18, Id = 58, Name = "Galewela", SinhalaName = "ගලේවල", TamilName = "கலேவலா" },
                new() { ZoneId = 18, Id = 59, Name = "Pallepola", SinhalaName = "පල්ලෙපොල", TamilName = "பலலெபொல" },

                new() { ZoneId = 19, Id = 60, Name = "Matale", SinhalaName = "මාතලේ", TamilName = "மாத்தலே" },
                new() { ZoneId = 19, Id = 61, Name = "Rattota", SinhalaName = "රත්තොට", TamilName = "ரதொட்ட" },
                new() { ZoneId = 19, Id = 62, Name = "Ukuwela", SinhalaName = "උකුවෙල", TamilName = "உகுவல" },
                new() { ZoneId = 19, Id = 63, Name = "Yatawatta", SinhalaName = "යටවත්ත", TamilName = "யடவட்ட" },

                new() { ZoneId = 20, Id = 64, Name = "Ambanganga Korale", SinhalaName = "අම්බන්ගංග කොරලේ", TamilName = "அம்பங்கங்கா கொரலே" },
                new() { ZoneId = 20, Id = 65, Name = "Naula", SinhalaName = "නාවුල", TamilName = "நௌலா" },

                new() { ZoneId = 21, Id = 66, Name = "Laggala", SinhalaName = "ලග්ගල", TamilName = "லக்கலா" },
                new() { ZoneId = 21, Id = 67, Name = "Wilgamuwa", SinhalaName = "විල්ගමුව", TamilName = "வில்கமுவ" },

                new() { ZoneId = 22, Id = 68, Name = "Udahewaheta", SinhalaName = "උඩහේවාහැට", TamilName = "உடஹேவஹெட்ட" },

                new() { ZoneId = 23, Id = 69, Name = "Ambagamuwa", SinhalaName = "අම්බගමුව", TamilName = "அம்பகமுவ" },
                new() { ZoneId = 23, Id = 70, Name = "Hatton Tamil - I", SinhalaName = "හැටන් දෙමළ - I", TamilName = "ஹட்டன் தமிழ் - I" },
                new() { ZoneId = 23, Id = 71, Name = "Hatton Tamil - II", SinhalaName = "හැටන් දෙමළ - II", TamilName = "ஹட்டன் தமிழ் - II" },
                new() { ZoneId = 23, Id = 72, Name = "Hatton Tamil - III", SinhalaName = "හැටන් දෙමළ - III", TamilName = "ஹட்டன் தமிழ் - III" },

                new() { ZoneId = 24, Id = 73, Name = "Kotmale", SinhalaName = "කොත්මලේ", TamilName = "கொத்மலே" },

                new() { ZoneId = 25, Id = 74, Name = "Nuwara Eliya", SinhalaName = "නුවර එළිය", TamilName = "நுவரெலியா" },
                new() { ZoneId = 25, Id = 75, Name = "Nuwara Eliya Tamil-1", SinhalaName = "නුවරඑළිය දෙමළ - 1", TamilName = "நுவரெலியா தமிழ் - 1" },
                new() { ZoneId = 25, Id = 76, Name = "Nuwara Eliya Tamil-2", SinhalaName = "නුවරඑළිය දෙමළ - 2", TamilName = "நுவரெலியா தமிழ் - 2" },
                new() { ZoneId = 25, Id = 77, Name = "Nuwara Eliya Tamil-3", SinhalaName = "නුවරඑළිය දෙමළ - 3", TamilName = "நுவரெலியா தமிழ் - 3" },

                new() { ZoneId = 26, Id = 78, Name = "Walapane", SinhalaName = "වලපනේ", TamilName = "வலபனே" }

            );

            modelBuilder.Entity<Language>().HasData(
                new() { Code = "si", Name = "Sinhala", IetfTag = "si-LK" },
                new() { Code = "ta", Name = "Tamil", IetfTag = "ta-LK" },
                new() { Code = "en", Name = "English", IetfTag = "en-UK" },
                new() { Code = "ar", Name = "Arabic", IetfTag = "ar-SA" }
            );

            modelBuilder.Entity<School>().HasData(
                new() { Id = 1, DivisionId = 56, CensusNo = "03270", Name = "AL-AQSA MUS.V", Location = "GUNNEPANA", Type = SchoolType.Type2 },
                new() { Id = 2, DivisionId = 56, CensusNo = "03263", Name = "MADINA N S", Location = "MADAWALA BAZAAR", Type = SchoolType.Type1AB }
            );

            modelBuilder.Entity<Class>().HasData(
                new() { Id = 1, SchoolId = 1, Section = "A", Grade = Grade.Grade1, LanguageCode = "ta" },
                new() { Id = 2, SchoolId = 1, Section = "A", Grade = Grade.Grade2, LanguageCode = "ta" },
                new() { Id = 3, SchoolId = 1, Section = "A", Grade = Grade.Grade3, LanguageCode = "ta" },
                new() { Id = 4, SchoolId = 1, Section = "A", Grade = Grade.Grade4, LanguageCode = "ta" },
                new() { Id = 5, SchoolId = 1, Section = "A", Grade = Grade.Grade5, LanguageCode = "ta" },
                new() { Id = 6, SchoolId = 1, Section = "A", Grade = Grade.Grade6, LanguageCode = "ta" },
                new() { Id = 7, SchoolId = 1, Section = "A", Grade = Grade.Grade7, LanguageCode = "ta" },
                new() { Id = 8, SchoolId = 1, Section = "A", Grade = Grade.Grade8, LanguageCode = "ta" },
                new() { Id = 9, SchoolId = 1, Section = "A", Grade = Grade.Grade9, LanguageCode = "ta" }
            );

            modelBuilder.Entity<AcademicYear>().HasData(
                new() { Year = 1998, StartDate = new DateOnly(1998, 1, 1), EndDate = new DateOnly(1998, 12, 31) },
                new() { Year = 1999, StartDate = new DateOnly(1999, 1, 1), EndDate = new DateOnly(1999, 12, 31) },
                new() { Year = 2024, StartDate = new DateOnly(2024, 1, 1), EndDate = new DateOnly(2024, 12, 31) },
                new() { Year = 2025, StartDate = new DateOnly(2025, 1, 1), EndDate = new DateOnly(2025, 12, 31) }
            );
        }

        private static void SeedPersons(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = 1,
                    FullName = "System Admin",
                    ShortName = "System",
                    Nickname = "Admin",
                    DateOfBirth = new DateOnly(2000, 01, 01),
                    BcNo = "111",
                    Sex = Sex.NotApplicable,
                    NicNo = "1111111111",
                    PassportNo = null,
                    MobileNo = "0000000000",
                    Email = "admin@system.com",
                    Address = "123, Kandy",
                },
                new Person
                {
                    Id = 2,
                    FullName = "Nifraz Navahz",
                    ShortName = "Nifraz",
                    Nickname = "Nifraz",
                    DateOfBirth = new DateOnly(1993, 03, 19),
                    BcNo = "123",
                    Sex = Sex.Male,
                    NicNo = "930793922V",
                    PassportNo = null,
                    MobileNo = "0712319319",
                    Email = "nifraz@live.com",
                    Address = "61/3, Napana, Gunnepana",
                },
                new Person
                {
                    Id = 3,
                    FullName = "Ayesha Rauf",
                    ShortName = "Ayesha",
                    Nickname = "Ayesha",
                    DateOfBirth = new DateOnly(1962, 03, 19),
                    BcNo = "123",
                    Sex = Sex.Female,
                    NicNo = null,
                    PassportNo = null,
                    MobileNo = "0776791138",
                    Email = "ayesha@live.com",
                    Address = "61/3, Napana, Gunnepana",
                },
                new Person
                {
                    Id = 4,
                    FullName = "Mohamad Navahz",
                    ShortName = "Navahz",
                    Nickname = "Navahz",
                    DateOfBirth = new DateOnly(1952, 03, 19),
                    BcNo = "123",
                    Sex = Sex.Male,
                    NicNo = null,
                    PassportNo = null,
                    MobileNo = "0756825831",
                    Email = "navahz@gmail.com",
                    Address = "61/3, Napana, Gunnepana",
                },
                new Person
                {
                    Id = 5,
                    FullName = "Nisry Ahamed",
                    ShortName = "Nisry",
                    Nickname = "Nisry",
                    DateOfBirth = new DateOnly(1980, 03, 19),
                    BcNo = "123",
                    Sex = Sex.Male,
                    NicNo = null,
                    PassportNo = null,
                    MobileNo = "0770808306",
                    Email = "nisry@gmail.com",
                    Address = "123, Madawala Bazaar",
                }

            );
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    PersonId = 1,
                    Password = PasswordHasher.HashPassword("1111"),
                    IsEmailVerified = true,
                    IsMobileNoVerified = true,
                },
                new User
                {
                    Id = 2,
                    PersonId = 2,
                    Password = PasswordHasher.HashPassword("2222"),
                    IsEmailVerified = true,
                    IsMobileNoVerified = true,
                },
                new User
                {
                    Id = 3,
                    PersonId = 3,
                    Password = PasswordHasher.HashPassword("3333"),
                    IsEmailVerified = true,
                    IsMobileNoVerified = true,
                },
                new User
                {
                    Id = 4,
                    PersonId = 4,
                    Password = PasswordHasher.HashPassword("4444"),
                    IsEmailVerified = true,
                    IsMobileNoVerified = true,
                },
                new User
                {
                    Id = 5,
                    PersonId = 5,
                    Password = PasswordHasher.HashPassword("5555"),
                    IsEmailVerified = true,
                    IsMobileNoVerified = true,
                }
            );
        }

        private static void SeedStudents(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    PersonId = 2,
                },
                new Student
                {
                    Id = 2,
                    PersonId = 3,
                }
            );
        }

        private static void SeedTeachers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    PersonId = 3,
                },
                new Teacher
                {
                    Id = 2,
                    PersonId = 4,
                },
                new Teacher
                {
                    Id = 3,
                    PersonId = 5,
                }
            );
        }

        private static void SeedPrincipals(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Principal>().HasData(
                new Principal
                {
                    Id = 1,
                    PersonId = 5,
                }
            );
        }

        private static void SeedOtherData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolStudentEnrollment>().HasData(
                new SchoolStudentEnrollment
                {
                    Id = 1,
                    SchoolId = 1,
                    No = 622,
                    StudentId = 1,
                    Status = EnrollmentStatus.Left,
                },
                new SchoolStudentEnrollment
                {
                    Id = 2,
                    SchoolId = 2,
                    No = 13336,
                    StudentId = 1,
                    Status = EnrollmentStatus.Completed,
                }
            );

            modelBuilder.Entity<ClassStudentEnrollment>().HasData(
                new ClassStudentEnrollment
                {
                    Id = 1,
                    ClassId = 1,
                    SchoolStudentEnrollmentId = 1,
                    AcademicYearYear = 1999,
                    Status = EnrollmentStatus.Completed,
                }
            );

            modelBuilder.Entity<SchoolTeacherEnrollment>().HasData(
                new SchoolTeacherEnrollment
                {
                    Id = 1,
                    SchoolId = 1,
                    No = 123,
                    TeacherId = 1,
                    Status = EnrollmentStatus.Retired,
                }
            );

            modelBuilder.Entity<ClassTeacherEnrollment>().HasData(
                new ClassTeacherEnrollment
                {
                    Id = 1,
                    SchoolTeacherEnrollmentId = 1,
                    AcademicYearYear = 1998,
                    ClassId = 6,
                    Status = EnrollmentStatus.Retired,
                }
            );

            modelBuilder.Entity<SchoolPrincipalEnrollment>().HasData(
                new SchoolPrincipalEnrollment
                {
                    Id = 1,
                    SchoolId = 1,
                    No = 123,
                    PrincipalId = 1,
                    Status = EnrollmentStatus.Active,
                }
            );
        }
    }
}
