using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DownCare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddActivityData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DropColumn(
                name: "TotalCommunicationScore",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "TotalLinguisticsScore",
                table: "Children");

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImagePath", "Label", "SoundPath" },
                values: new object[] { "/Images/OneWord/أرنب.jpg", "أرنب", "/Sound/OneWord/أرنب.mp3" });

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImagePath", "Label", "SoundPath" },
                values: new object[] { "/Images/OneWord/استيكه.png", "استيكه", "/Sound/OneWord/استيكه.mp3" });

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "ImagePath", "Label", "SoundPath", "Type" },
                values: new object[] { "/Images/FourWord/البنت تلعب مع الكلب.png", "البنت تلعب مع الكلب", "/Sound/FourWord/البنت تلعب مع الكلب.mp3", "FourWord" });

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "ImagePath", "Label", "SoundPath", "Type" },
                values: new object[] { "/Images/FourWord/السمك يعيش فى الماء.png", "السمك يعيش فى الماء", "/Sound/FourWord/السمك يعيش فى الماء.mp3", "FourWord" });

            migrationBuilder.InsertData(
                table: "ActivitiyData",
                columns: new[] { "Id", "ImagePath", "Label", "SoundPath", "Type" },
                values: new object[,]
                {
                    { 3, "/Images/OneWord/أسد.jpg", "أسد", "/Sound/OneWord/أسد.mp3", "OneWord" },
                    { 4, "/Images/OneWord/أسنان.jpg", "أسنان", "/Sound/OneWord/أسنان.mp3", "OneWord" },
                    { 5, "/Images/OneWord/برايه.png", "برايه", "/Sound/OneWord/برايه.mp3", "OneWord" },
                    { 6, "/Images/OneWord/بطاطس.jpg", "بطاطس", "/Sound/OneWord/بطاطس.mp3", "OneWord" },
                    { 7, "/Images/OneWord/بطة.jpg", "بطة", "/Sound/OneWord/بطة.mp3", "OneWord" },
                    { 8, "/Images/OneWord/بنت.jpg", "بنت", "/Sound/OneWord/بنت.mp3", "OneWord" },
                    { 9, "/Images/OneWord/تفاحة.jpg", "تفاحة", "/Sound/OneWord/تفاحة.mp3", "OneWord" },
                    { 10, "/Images/OneWord/جزر.jpg", "جزر", "/Sound/OneWord/جزر.mp3", "OneWord" },
                    { 11, "/Images/OneWord/جمل.jpg", "جمل", "/Sound/OneWord/جمل.mp3", "OneWord" },
                    { 12, "/Images/OneWord/حصان.jpg", "حصان", "/Sound/OneWord/حصان.mp3", "OneWord" },
                    { 13, "/Images/OneWord/حلة.png", "حلة", "/Sound/OneWord/حلة.mp3", "OneWord" },
                    { 14, "/Images/OneWord/خروف.jpg", "خروف", "/Sound/OneWord/خروف.mp3", "OneWord" },
                    { 15, "/Images/OneWord/خيار.jpg", "خيار", "/Sound/OneWord/خيار.mp3", "OneWord" },
                    { 16, "/Images/OneWord/سكينة.jpg", "سكينة", "/Sound/OneWord/سكينة.mp3", "OneWord" },
                    { 17, "/Images/OneWord/سمكة.jpg", "سمكة", "/Sound/OneWord/سمكة.mp3", "OneWord" },
                    { 18, "/Images/OneWord/شنطه.png", "شنطه", "/Sound/OneWord/شنطه.mp3", "OneWord" },
                    { 19, "/Images/OneWord/شوكة.jpg", "شوكة", "/Sound/OneWord/شوكة.mp3", "OneWord" },
                    { 20, "/Images/OneWord/عين.jpg", "عين", "/Sound/OneWord/عين.mp3", "OneWord" },
                    { 21, "/Images/OneWord/غزالة.jpg", "غزالة", "/Sound/OneWord/غزالة.mp3", "OneWord" },
                    { 22, "/Images/OneWord/فراولة.jpg", "فراولة", "/Sound/OneWord/فراولة.mp3", "OneWord" },
                    { 23, "/Images/OneWord/فيل.jpg", "فيل", "/Sound/OneWord/فيل.mp3", "OneWord" },
                    { 24, "/Images/OneWord/كتاب.png", "كتاب", "/Sound/OneWord/كتاب.mp3", "OneWord" },
                    { 25, "/Images/OneWord/كراسه.png", "كراسه", "/Sound/OneWord/كراسه.mp3", "OneWord" },
                    { 26, "/Images/OneWord/كلب.jpg", "كلب", "/Sound/OneWord/كلب.mp3", "OneWord" },
                    { 27, "/Images/OneWord/لسان.jpg", "لسان", "/Sound/OneWord/لسان.mp3", "OneWord" },
                    { 28, "/Images/OneWord/ولد.jpg", "ولد", "/Sound/OneWord/ولد.mp3", "OneWord" },
                    { 29, "/Images/OneWord/منجا.png", "مانجا", "/Sound/OneWord/منجا.mp3", "OneWord" },
                    { 30, "/Images/OneWord/موز.png", "موز", "/Sound/OneWord/موز.mp3", "OneWord" },
                    { 31, "/Images/TwoWord/الولد يكتب.jpg", "الولد يكتب", "/Sound/TwoWord/الولد يكتب.mp3", "TwoWord" },
                    { 32, "/Images/TwoWord/الولد ينام.jpg", "الولد ينام", "/Sound/TwoWord/الولد ينام.mp3", "TwoWord" },
                    { 33, "/Images/TwoWord/أجرى بسرعة.jpg", "أجرى بسرعة", "/Sound/TwoWord/أجرى بسرعة.mp3", "TwoWord" },
                    { 34, "/Images/TwoWord/أذهب للمدرسة.jpg", "أذهب للمدرسة", "/Sound/TwoWord/أذهب للمدرسة.mp3", "TwoWord" },
                    { 35, "/Images/TwoWord/أركب الدراجة.jpg", "أركب الدراجة", "/Sound/TwoWord/أركب الدراجة.mp3", "TwoWord" },
                    { 36, "/Images/TwoWord/أساعد أمى.jpg", "أساعد أمى", "/Sound/TwoWord/أساعد أمى.mp3", "TwoWord" },
                    { 37, "/Images/TwoWord/استيقظ مبكرا.jpg", "استيقظ مبكرا", "/Sound/TwoWord/استيقظ مبكرا.mp3", "TwoWord" },
                    { 38, "/Images/TwoWord/أشاهد التليفزيون.jpg", "أشاهد التليفزيون", "/Sound/TwoWord/أشاهد التليفزيون.mp3", "TwoWord" },
                    { 39, "/Images/TwoWord/أغسل اسنانى.jpg", "أغسل اسنانى", "/Sound/TwoWord/أغسل اسنانى.mp3", "TwoWord" },
                    { 40, "/Images/TwoWord/أغنى أغنية.jpg", "أغنى أغنية", "/Sound/TwoWord/أغنى أغنية.mp3", "TwoWord" },
                    { 41, "/Images/TwoWord/أقرأ كتاب.jpg", "أقرأ كتاب", "/Sound/TwoWord/أقرأ كتاب.mp3", "TwoWord" },
                    { 42, "/Images/TwoWord/حديقة الحيوان.jpg", "حديقة الحيوان", "/Sound/TwoWord/حديقة الحيوان.mp3", "TwoWord" },
                    { 43, "/Images/TwoWord/أكتب الواجب.jpg", "أكتب الواجب", "/Sound/TwoWord/أكتب الواجب.mp3", "TwoWord" },
                    { 44, "/Images/TwoWord/أكل سندوتش.jpg", "أكل سندوتش", "/Sound/TwoWord/أكل سندوتش.mp3", "TwoWord" },
                    { 45, "/Images/TwoWord/الأسد يزئر.jpg", "الأسد يزئر", "/Sound/TwoWord/الأسد يزئر.mp3", "TwoWord" },
                    { 46, "/Images/TwoWord/ألبس ملابسى.jpg", "ألبس ملابسى", "/Sound/TwoWord/ألبس ملابسى.mp3", "TwoWord" },
                    { 47, "/Images/TwoWord/البطة تسبح.jpg", "البطة تسبح", "/Sound/TwoWord/البطة تسبح.mp3", "TwoWord" },
                    { 48, "/Images/TwoWord/البنت تطبخ.jpg", "البنت تطبخ", "/Sound/TwoWord/البنت تطبخ.mp3", "TwoWord" },
                    { 49, "/Images/TwoWord/الحصان سريع.jpg", "الحصان سريع", "/Sound/TwoWord/الحصان سريع.mp3", "TwoWord" },
                    { 50, "/Images/TwoWord/الدب كبير.jpg", "الدب كبير", "/Sound/TwoWord/الدب كبير.mp3", "TwoWord" },
                    { 51, "/Images/TwoWord/الزرافة طويلة.jpg", "الزرافة طويلة", "/Sound/TwoWord/الزرافة طويلة.mp3", "TwoWord" },
                    { 52, "/Images/TwoWord/ألعب بالكرة.jpg", "ألعب بالكرة", "/Sound/TwoWord/ألعب بالكرة.mp3", "TwoWord" },
                    { 53, "/Images/TwoWord/الفيل ضخم.jpg", "الفيل ضخم", "/Sound/TwoWord/الفيل ضخم.mp3", "TwoWord" },
                    { 54, "/Images/TwoWord/الولد يأكل.jpg", "الولد يأكل", "/Sound/TwoWord/الولد يأكل.mp3", "TwoWord" },
                    { 55, "/Images/TwoWord/الولد يذاكر.jpg", "الولد يذاكر", "/Sound/TwoWord/الولد يذاكر.mp3", "TwoWord" },
                    { 56, "/Images/TwoWord/الولد يرسم.jpg", "الولد يرسم", "/Sound/TwoWord/الولد يرسم.mp3", "TwoWord" },
                    { 57, "/Images/TwoWord/الولد يزرع.jpg", "الولد يزرع", "/Sound/TwoWord/الولد يزرع.mp3", "TwoWord" },
                    { 58, "/Images/TwoWord/الولد يسبح.jpg", "الولد يسبح", "/Sound/TwoWord/الولد يسبح.mp3", "TwoWord" },
                    { 59, "/Images/TwoWord/الولد يشرب.jpg", "الولد يشرب", "/Sound/TwoWord/الولد يشرب.mp3", "TwoWord" },
                    { 60, "/Images/TwoWord/الولد يصطاد.jpg", "الولد يصطاد", "/Sound/TwoWord/الولد يصطاد.mp3", "TwoWord" },
                    { 61, "/Images/ThreeWord/اسرح شعري بالمشط.jpg", "اسرح شعري بالمشط", "/Sound/ThreeWord/اسرح شعري بالمشط.mp3", "ThreeWord" },
                    { 62, "/Images/ThreeWord/الولد يلعب بالكرة.jpg", "الولد يلعب بالكرة", "/Sound/ThreeWord/الولد يلعب بالكرة.mp3", "ThreeWord" },
                    { 63, "/Images/ThreeWord/اشرب عصير برتقان.jpg", "اشرب عصير برتقان", "/Sound/ThreeWord/اشرب عصير برتقان.mp3", "ThreeWord" },
                    { 64, "/Images/ThreeWord/اغسل يدي بالماء.png", "اغسل يدي بالماء", "/Sound/ThreeWord/اغسل يدي بالماء.mp3", "ThreeWord" },
                    { 65, "/Images/ThreeWord/الأرنب يحب الجزر.png", "الأرنب يحب الجزر", "/Sound/ThreeWord/الأرنب يحب الجزر.mp3", "ThreeWord" },
                    { 66, "/Images/ThreeWord/الاطفال يلعبون بالكره.jpg", "الاطفال يلعبون بالكره", "/Sound/ThreeWord/الاطفال يلعبون بالكره.mp3", "ThreeWord" },
                    { 67, "/Images/ThreeWord/البقرة تأكل العشب.jpg", "البقرة تأكل العشب", "/Sound/ThreeWord/البقرة تأكل العشب.mp3", "ThreeWord" },
                    { 68, "/Images/ThreeWord/البنت بتعمل الواجب.png", "البنت بتعمل الواجب", "/Sound/ThreeWord/البنت بتعمل الواجب.mp3", "ThreeWord" },
                    { 69, "/Images/ThreeWord/البنت بتلعب الموسيقى.png", "البنت بتلعب الموسيقى", "/Sound/ThreeWord/البنت بتلعب الموسيقى.mp3", "ThreeWord" },
                    { 70, "/Images/ThreeWord/البنت تشرب العصير.jpg", "البنت تشرب العصير", "/Sound/ThreeWord/البنت تشرب العصير.mp3", "ThreeWord" },
                    { 71, "/Images/ThreeWord/البنت تقرأ كتاب.png", "البنت تقرأ كتاب", "/Sound/ThreeWord/البنت تقرأ كتاب.mp3", "ThreeWord" },
                    { 72, "/Images/ThreeWord/القطه تأكل السمك.png", "القطه تأكل السمك", "/Sound/ThreeWord/القطه تأكل السمك.mp3", "ThreeWord" },
                    { 73, "/Images/ThreeWord/الكلب يأكل العظم.png", "الكلب يأكل العظم", "/Sound/ThreeWord/الكلب يأكل العظم.mp3", "ThreeWord" },
                    { 74, "/Images/ThreeWord/الولد والبنت بيلعبوا.jpg", "الولد والبنت بيلعبوا", "/Sound/ThreeWord/الولد والبنت بيلعبوا.mp3", "ThreeWord" },
                    { 75, "/Images/ThreeWord/الولد يأكل الطعام.png", "الولد يأكل الطعام", "/Sound/ThreeWord/الولد يأكل الطعام.mp3", "ThreeWord" },
                    { 76, "/Images/ThreeWord/الولد يجري بسرعة.jpg", "الولد يجري بسرعة", "/Sound/ThreeWord/الولد يجري بسرعة.mp3", "ThreeWord" },
                    { 77, "/Images/ThreeWord/الولد يحب الحيوانات.jpg", "الولد يحب الحيوانات", "/Sound/ThreeWord/الولد يحب الحيوانات.mp3", "ThreeWord" },
                    { 78, "/Images/ThreeWord/الولد يذهب للمدرسه.png", "الولد يذهب للمدرسه", "/Sound/ThreeWord/الولد يذهب للمدرسه.mp3", "ThreeWord" },
                    { 79, "/Images/ThreeWord/الولد يرسم المنزل.png", "الولد يرسم المنزل", "/Sound/ThreeWord/الولد يرسم المنزل.mp3", "ThreeWord" },
                    { 80, "/Images/ThreeWord/الولد يزرع شجرة.jpg", "الولد يزرع شجرة", "/Sound/ThreeWord/الولد يزرع شجرة.mp3", "ThreeWord" },
                    { 81, "/Images/ThreeWord/الولد يشرب الماء.png", "الولد يشرب الماء", "/Sound/ThreeWord/الولد يشرب الماء.mp3", "ThreeWord" },
                    { 82, "/Images/ThreeWord/الولد يصطاد السمك.png", "الولد يصطاد السمك", "/Sound/ThreeWord/الولد يصطاد السمك.mp3", "ThreeWord" },
                    { 83, "/Images/ThreeWord/الولد يغسل اسنانه.png", "الولد يغسل اسنانه", "/Sound/ThreeWord/الولد يغسل اسنانه.mp3", "ThreeWord" },
                    { 84, "/Images/ThreeWord/الولد يلبس البنطلون.jpg", "الولد يلبس البنطلون", "/Sound/ThreeWord/الولد يلبس البنطلون.mp3", "ThreeWord" },
                    { 85, "/Images/ThreeWord/الولد يلبس القميص.jpg", "الولد يلبس القميص", "/Sound/ThreeWord/الولد يلبس القميص.mp3", "ThreeWord" },
                    { 86, "/Images/ThreeWord/الولد يلعب المرجيحه.jpg", "الولد يلعب المرجيحه", "/Sound/ThreeWord/الولد يلعب المرجيحه.mp3", "ThreeWord" },
                    { 87, "/Images/ThreeWord/تغسل امى الملابس.jpg", "تغسل امى الملابس", "/Sound/ThreeWord/تغسل امى الملابس.mp3", "ThreeWord" },
                    { 88, "/Images/ThreeWord/البنت تلعب بالعروسة.png", "البنت تلعب بالعروسة", "/Sound/ThreeWord/البنت تلعب بالعروسة.mp3", "ThreeWord" },
                    { 89, "/Images/ThreeWord/الاستحمام بالماء منعش.jpg", "الاستحمام بالماء منعش", "/Sound/ThreeWord/الاستحمام بالماء منعش.mp3", "ThreeWord" },
                    { 90, "/Images/ThreeWord/ما اجمل النوم.jpg", "ما اجمل النوم", "/Sound/ThreeWord/ما اجمل النوم.mp3", "ThreeWord" },
                    { 91, "/Images/FourWord/استحم بالماء والصابون والشامبو.jpg", "استحم بالماء والصابون والشامبو", "/Sound/FourWord/استحم بالماء والصابون والشامبو.mp3", "FourWord" },
                    { 92, "/Images/FourWord/أسرح شعرى بالفرشاة والزيت.png", "أسرح شعرى بالفرشاة والزيت", "/Sound/FourWord/أسرح شعرى بالفرشاة والزيت.mp3", "FourWord" },
                    { 93, "/Images/FourWord/اغسل اسنانى بالفرشاة والمعجون.png", "اغسل اسنانى بالفرشاة والمعجون", "/Sound/FourWord/اغسل اسنانى بالفرشاة والمعجون.mp3", "FourWord" },
                    { 94, "/Images/FourWord/اغسل يدي بالماء والصابون.png", "اغسل يدي بالماء والصابون", "/Sound/FourWord/اغسل يدي بالماء والصابون.mp3", "FourWord" },
                    { 95, "/Images/FourWord/الاب بيزعق لابنه غاضبا.png", "الاب بيزعق لابنه غاضبا", "/Sound/FourWord/الاب بيزعق لابنه غاضبا.mp3", "FourWord" },
                    { 96, "/Images/FourWord/الاب يعطي ابنته هديه.png", "الاب يعطي ابنته هديه", "/Sound/FourWord/الاب يعطي ابنته هديه.mp3", "FourWord" },
                    { 97, "/Images/FourWord/الاطفال يلعبون على الشاطئ.jpg", "الاطفال يلعبون على الشاطئ", "/Sound/FourWord/الاطفال يلعبون على الشاطئ.mp3", "FourWord" },
                    { 98, "/Images/FourWord/الأولاد يلعبون فى الحديقة.png", "الأولاد يلعبون فى الحديقة", "/Sound/FourWord/الأولاد يلعبون فى الحديقة.mp3", "FourWord" },
                    { 99, "/Images/FourWord/البنت ترسم شمس وورود.png", "البنت ترسم شمس وورود", "/Sound/FourWord/البنت ترسم شمس وورود.mp3", "FourWord" },
                    { 100, "/Images/FourWord/البنت تساعد امها بالمطبخ.jpg", "البنت تساعد امها بالمطبخ", "/Sound/FourWord/البنت تساعد امها بالمطبخ.mp3", "FourWord" },
                    { 103, "/Images/FourWord/الطبيب يعطي المريض حقنة.png", "الطبيب يعطي المريض حقنة", "/Sound/FourWord/الطبيب يعطي المريض حقنة.mp3", "FourWord" },
                    { 104, "/Images/FourWord/الطفل يقرأ الكتاب بأهتمام.png", "الطفل يقرأ الكتاب بأهتمام", "/Sound/FourWord/الطفل يقرأ الكتاب بأهتمام.mp3", "FourWord" },
                    { 105, "/Images/FourWord/العائلة كلها تساعد الام.jpg", "العائلة كلها تساعد الام", "/Sound/FourWord/العائلة كلها تساعد الام.mp3", "FourWord" },
                    { 106, "/Images/FourWord/ألعب الكرة مع الاصدقاء.jpg", "ألعب الكرة مع الاصدقاء", "/Sound/FourWord/ألعب الكرة مع الاصدقاء.mp3", "FourWord" },
                    { 107, "/Images/FourWord/ألعب بالألعاب مع اختى.png", "ألعب بالألعاب مع اختى", "/Sound/FourWord/ألعب بالألعاب مع اختى.mp3", "FourWord" },
                    { 108, "/Images/FourWord/المستشفى مكان لعلاج المرضى.jpg", "المستشفى مكان لعلاج المرضى", "/Sound/FourWord/المستشفى مكان لعلاج المرضى.mp3", "FourWord" },
                    { 109, "/Images/FourWord/المعلمة تقرأ قصة للأطفال.jpg", "المعلمة تقرأ قصة للأطفال", "/Sound/FourWord/المعلمة تقرأ قصة للأطفال.mp3", "FourWord" },
                    { 110, "/Images/FourWord/الولد يساعد امه ف التنظيف.jpg", "الولد يساعد امه ف التنظيف", "/Sound/FourWord/الولد يساعد امه ف التنظيف.mp3", "FourWord" },
                    { 111, "/Images/FourWord/الولد يسبح فى البحر.jpg", "الولد يسبح فى البحر", "/Sound/FourWord/الولد يسبح فى البحر.mp3", "FourWord" },
                    { 112, "/Images/FourWord/الولد يشرب عصير برتقان.png", "الولد يشرب عصير برتقان", "/Sound/FourWord/الولد يشرب عصير برتقان.mp3", "FourWord" },
                    { 113, "/Images/FourWord/الولد يصطاد السمك بالصنارة.png", "الولد يصطاد السمك بالصنارة", "/Sound/FourWord/الولد يصطاد السمك بالصنارة.mp3", "FourWord" },
                    { 114, "/Images/FourWord/الولد يغسل اسنانة بالفرشاة.png", "الولد يغسل اسنانة بالفرشاة", "/Sound/FourWord/الولد يغسل اسنانة بالفرشاة.mp3", "FourWord" },
                    { 115, "/Images/FourWord/الولد يلعب مع القطه.png", "الولد يلعب مع القطه", "/Sound/FourWord/الولد يلعب مع القطه.mp3", "FourWord" },
                    { 116, "/Images/FourWord/انا واختى نقرأ الكتب.png", "انا واختى نقرأ الكتب", "/Sound/FourWord/انا واختى نقرأ الكتب.mp3", "FourWord" },
                    { 117, "/Images/FourWord/تسقي البنت الازهار الجميلة.png", "تسقي البنت الازهار الجميلة", "/Sound/FourWord/تسقي البنت الازهار الجميلة.mp3", "FourWord" },
                    { 118, "/Images/FourWord/تشرح المعلمة الدرس جيدا.png", "تشرح المعلمة الدرس جيدا", "/Sound/FourWord/تشرح المعلمة الدرس جيدا.mp3", "FourWord" },
                    { 119, "/Images/FourWord/تغسل البنت التفاح بالماء.png", "تغسل البنت التفاح بالماء", "/Sound/FourWord/تغسل البنت التفاح بالماء.mp3", "FourWord" },
                    { 120, "/Images/FourWord/ما اجمل قراءة الكتب.png", "ما اجمل قراءة الكتب", "/Sound/FourWord/ما اجمل قراءة الكتب.mp3", "FourWord" },
                    { 121, "/Images/FiveWord/أذهب الى المدرسة مع اصحابي.jpg", "أذهب الى المدرسة مع اصحابي", "/Sound/FiveWord/أذهب الى المدرسة مع اصحابي.mp3", "FiveWord" },
                    { 122, "/Images/FiveWord/اشارة المرور حمرة و صفرة وخضرة.png", "اشارة المرور حمرة و صفرة وخضرة", "/Sound/FiveWord/اشارة المرور حمرة و صفرة وخضرة.mp3", "FiveWord" },
                    { 123, "/Images/FiveWord/البنت بتاكل فاكهة وسندوتش وتشرب عصير.png", "البنت بتاكل فاكهة وسندوتش وتشرب عصير", "/Sound/FiveWord/البنت بتاكل فاكهة وسندوتش وتشرب عصير.mp3", "FiveWord" },
                    { 124, "/Images/FiveWord/البنت ترسم شمس و ورود بالألوان.png", "البنت ترسم شمس و ورود بالألوان", "/Sound/FiveWord/البنت ترسم شمس و ورود بالألوان.mp3", "FiveWord" },
                    { 125, "/Images/FiveWord/البنت تسقى الأزهار فى الصبح.png", "البنت تسقى الأزهار فى الصبح", "/Sound/FiveWord/البنت تسقى الأزهار فى الصبح.mp3", "FiveWord" },
                    { 126, "/Images/FiveWord/الجزار يقطع اللحم قطع بالسكينة.png", "الجزار يقطع اللحم قطع بالسكينة", "/Sound/FiveWord/الجزار يقطع اللحم قطع بالسكينة.mp3", "FiveWord" },
                    { 127, "/Images/FiveWord/السواق يقود الاتوبيس على الطريق.jpg", "السواق يقود الاتوبيس على الطريق", "/Sound/FiveWord/السواق يقود الاتوبيس على الطريق.mp3", "FiveWord" },
                    { 128, "/Images/FiveWord/الشمس تنور السما فى النهار.jpg", "الشمس تنور السما فى النهار", "/Sound/FiveWord/الشمس تنور السما فى النهار.mp3", "FiveWord" },
                    { 129, "/Images/FiveWord/الطفل يتفرج الكارتون على التليفزيون.png", "الطفل يتفرج الكارتون على التليفزيون", "/Sound/FiveWord/الطفل يتفرج الكارتون على التليفزيون.mp3", "FiveWord" },
                    { 130, "/Images/FiveWord/الطيار يقود الطيارة فى السما.png", "الطيار يقود الطيارة فى السما", "/Sound/FiveWord/الطيار يقود الطيارة فى السما.mp3", "FiveWord" },
                    { 131, "/Images/FiveWord/الطيور تطير فى السما الزرقا.jpg", "الطيور تطير فى السما الزرقا", "/Sound/FiveWord/الطيور تطير فى السما الزرقا.mp3", "FiveWord" },
                    { 132, "/Images/FiveWord/ألعب الكرة مع اصحابي فى الملعب.jpg", "ألعب الكرة مع اصحابي فى الملعب", "/Sound/FiveWord/ألعب الكرة مع اصحابي فى الملعب.mp3", "FiveWord" },
                    { 133, "/Images/FiveWord/الفراشات تطير حول الأزهار الجميلة.jpg", "الفراشات تطير حول الأزهار الجميلة", "/Sound/FiveWord/الفراشات تطير حول الأزهار الجميلة.mp3", "FiveWord" },
                    { 134, "/Images/FiveWord/الفلاح يحصد القمح من الحقل.jpg", "الفلاح يحصد القمح من الحقل", "/Sound/FiveWord/الفلاح يحصد القمح من الحقل.mp3", "FiveWord" },
                    { 135, "/Images/FiveWord/القمر ينور السما فى الليل.jpg", "القمر ينور السما فى الليل", "/Sound/FiveWord/القمر ينور السما فى الليل.mp3", "FiveWord" },
                    { 136, "/Images/FiveWord/اَلْمُدَرِّسَةُ بتقرأ قصة للأطفال في الفصل.jpg", "اَلْمُدَرِّسَةُ بتقرأ قصة للأطفال في الفصل", "/Sound/FiveWord/اَلْمُدَرِّسَةُ بتقرأ قصة للأطفال في الفصل.mp3", "FiveWord" },
                    { 137, "/Images/FiveWord/المطرب يغنى اغنية فى الحفلة.png", "المطرب يغنى اغنية فى الحفلة", "/Sound/FiveWord/المطرب يغنى اغنية فى الحفلة.mp3", "FiveWord" },
                    { 138, "/Images/FiveWord/الميكانيكي يصلح العربية فى الورشه.png", "الميكانيكي يصلح العربية فى الورشه", "/Sound/FiveWord/الميكانيكي يصلح العربية فى الورشه.mp3", "FiveWord" },
                    { 139, "/Images/FiveWord/الولد يصطاد السمك من البحيرة بالصنارة.png", "الولد يصطاد السمك من البحيرة بالصنارة", "/Sound/FiveWord/الولد يصطاد السمك من البحيرة بالصنارة.mp3", "FiveWord" },
                    { 140, "/Images/FiveWord/الولد يغسل اسنانة بالفرشاة والمعجون.png", "الولد يغسل اسنانة بالفرشاة والمعجون", "/Sound/FiveWord/الولد يغسل اسنانة بالفرشاة والمعجون.mp3", "FiveWord" },
                    { 141, "/Images/FiveWord/الولد يقرأ الكتب فى المكتبة.png", "الولد يقرأ الكتب فى المكتبة", "/Sound/FiveWord/الولد يقرأ الكتب فى المكتبة.mp3", "FiveWord" },
                    { 142, "/Images/FiveWord/الولد يلعب مع اصحابه فى الحديقة.jpg", "الولد يلعب مع اصحابه فى الحديقة", "/Sound/FiveWord/الولد يلعب مع اصحابه فى الحديقة.mp3", "FiveWord" },
                    { 143, "/Images/FiveWord/انا بحب ابويا وامى واختى.png", "انا بحب ابويا وامى واختى", "/Sound/FiveWord/انا بحب ابويا وامى واختى.mp3", "FiveWord" },
                    { 144, "/Images/FiveWord/تشرح اَلْمُدَرِّسَةُ الدروس للأطفال فى المدرسة.jpg", "تشرح اَلْمُدَرِّسَةُ الدروس للأطفال فى المدرسة", "/Sound/FiveWord/تشرح اَلْمُدَرِّسَةُ الدروس للأطفال فى المدرسة.mp3", "FiveWord" },
                    { 145, "/Images/FiveWord/رجل المطافي يطفي الحريق الضخم.png", "رجل المطافي يطفي الحريق الضخم", "/Sound/FiveWord/رجل المطافي يطفي الحريق الضخم.mp3", "FiveWord" },
                    { 146, "/Images/FiveWord/يحمل الفلاح سلة الفواكه والخضراوات.png", "يحمل الفلاح سلة الفواكه والخضراوات", "/Sound/FiveWord/يحمل الفلاح سلة الفواكه والخضراوات.mp3", "FiveWord" },
                    { 147, "/Images/FiveWord/يرسم المهندس خريطة جديدة للمنزل.png", "يرسم المهندس خريطة جديدة للمنزل", "/Sound/FiveWord/يرسم المهندس خريطة جديدة للمنزل.mp3", "FiveWord" },
                    { 148, "/Images/FiveWord/يطبخ الطباخ الطعام فى المطعم.png", "يطبخ الطباخ الطعام فى المطعم", "/Sound/FiveWord/يطبخ الطباخ الطعام فى المطعم.mp3", "FiveWord" },
                    { 149, "/Images/FiveWord/يعالج الطبيب الطفل المريض فى المستشفى.png", "يعالج الطبيب الطفل المريض فى المستشفى", "/Sound/FiveWord/يعالج الطبيب الطفل المريض فى المستشفى.mp3", "FiveWord" },
                    { 150, "/Images/FiveWord/يكتب الطالب الدرس فى الكراسة.png", "يكتب الطالب الدرس فى الكراسة", "/Sound/FiveWord/يكتب الطالب الدرس فى الكراسة.mp3", "FiveWord" }
                });

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 19, 18, 33, 38, 444, DateTimeKind.Local).AddTicks(2102));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.AddColumn<int>(
                name: "TotalCommunicationScore",
                table: "Children",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalLinguisticsScore",
                table: "Children",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImagePath", "Label", "SoundPath" },
                values: new object[] { "Images/منجا.png", "منجا", "Sound/منجا.mp3" });

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImagePath", "Label", "SoundPath" },
                values: new object[] { "/Images/موز.png", "موز", "/Sound/موز.mp3" });

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "ImagePath", "Label", "SoundPath", "Type" },
                values: new object[] { "/Images/الولد يكتب.jpg", "الولد يكتب", "/Sound/الولد يكتب.mp3", "TwoWord" });

            migrationBuilder.UpdateData(
                table: "ActivitiyData",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "ImagePath", "Label", "SoundPath", "Type" },
                values: new object[] { "/Images/الولد ينام.jpg", "الولد ينام", "/Sound/الولد ينام.mp3", "TwoWord" });

            migrationBuilder.InsertData(
                table: "ActivitiyData",
                columns: new[] { "Id", "ImagePath", "Label", "SoundPath", "Type" },
                values: new object[,]
                {
                    { 201, "/Images/فتاة تشرب العصير.jpg", "فتاة تشرب العصير", "/Sound/فتاة تشرب العصير.mp3", "ThreeWord" },
                    { 202, "/Images/الولد يلعب بالكرة.jpg", "الولد يلعب بالكرة", "/Sound/الولد يلعب بالكرة.mp3", "ThreeWord" }
                });

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 25, 12, 48, 56, 407, DateTimeKind.Local).AddTicks(3234));
        }
    }
}
