using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DatingApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RestructuringTheData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "Country", "Created", "DateOfBirth", "Gender", "Interests", "Introduction", "KnownAs", "LastActive", "LookingFor", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[,]
                {
                    { 1, "Southview", "Equatorial Guinea", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1993, 7, 21), "female", "Sit ea proident do anim irure voluptate quis nisi minim nisi ipsum.", "Cillum in enim do ex deserunt quis consequat nulla officia ea. Commodo esse reprehenderit labore velit adipisicing nulla. Veniam pariatur nisi magna occaecat cillum veniam duis ad. Culpa id duis amet irure laborum veniam est ad exercitation.\r\n", "Leonor", new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Excepteur ipsum aliquip et deserunt dolor ullamco dolore velit et consectetur. Consequat commodo culpa aliqua mollit irure laborum proident ea. Cupidatat consectetur culpa nulla nostrud ad cillum. Culpa nulla laboris sit magna veniam consectetur laboris reprehenderit enim sunt consectetur veniam adipisicing. Ut ad in veniam dolore proident. Magna esse id ut adipisicing reprehenderit consequat est sunt ipsum commodo dolore. Mollit exercitation voluptate nulla minim cillum exercitation excepteur nulla ad in.\r\n", new byte[] { 165, 196, 78, 222, 155, 107, 19, 211, 26, 12, 168, 181, 44, 176, 46, 178, 164, 81, 22, 3, 47, 148, 109, 106, 212, 18, 17, 252, 202, 118, 115, 57, 188, 161, 186, 36, 34, 203, 83, 165, 43, 62, 24, 97, 219, 103, 40, 118, 136, 98, 114, 32, 17, 21, 70, 21, 164, 226, 44, 100, 107, 66, 119, 3 }, new byte[] { 103, 189, 170, 106, 217, 249, 253, 212, 149, 80, 250, 51, 239, 69, 109, 114, 238, 26, 173, 90, 162, 164, 12, 51, 110, 169, 207, 72, 253, 96, 172, 239, 50, 103, 49, 39, 243, 28, 230, 211, 215, 178, 163, 245, 142, 90, 3, 235, 208, 223, 55, 244, 8, 66, 194, 94, 104, 139, 45, 161, 126, 196, 218, 116, 202, 14, 138, 126, 161, 58, 138, 165, 234, 13, 4, 3, 115, 211, 224, 154, 162, 158, 191, 53, 174, 234, 255, 124, 212, 247, 11, 152, 185, 195, 223, 96, 248, 15, 18, 53, 81, 239, 202, 108, 103, 126, 215, 157, 205, 231, 123, 139, 186, 66, 213, 203, 157, 60, 23, 181, 201, 173, 213, 203, 70, 111, 212, 151 }, "leonor" },
                    { 2, "Statenville", "Algeria", new DateTime(2020, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1960, 3, 10), "female", "Tempor qui laboris veniam est excepteur dolore Lorem dolore aute irure pariatur consequat.", "Sint adipisicing laboris ipsum voluptate in. Mollit eu consequat aliquip sint qui ad mollit amet nulla eiusmod. Laboris tempor ad ut duis velit sit ullamco ut pariatur aliquip irure.\r\n", "Eleanor", new DateTime(2020, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eiusmod sunt aute duis sint ex nisi amet et anim in mollit velit ad. Anim minim excepteur irure non cupidatat officia consectetur ea cupidatat est est velit. Minim sunt elit aute commodo amet Lorem.\r\n", new byte[] { 72, 133, 227, 191, 124, 247, 215, 82, 87, 101, 116, 184, 178, 220, 87, 67, 247, 64, 226, 168, 117, 69, 3, 99, 112, 30, 147, 62, 226, 236, 225, 180, 171, 90, 236, 246, 63, 255, 177, 96, 196, 172, 79, 92, 52, 91, 166, 186, 223, 225, 191, 28, 164, 160, 7, 68, 120, 112, 242, 20, 252, 44, 61, 178 }, new byte[] { 91, 247, 71, 0, 232, 241, 7, 24, 140, 159, 255, 1, 156, 253, 254, 106, 58, 75, 222, 210, 50, 103, 222, 99, 157, 189, 31, 136, 124, 250, 153, 88, 125, 86, 209, 185, 108, 101, 209, 233, 39, 114, 57, 88, 63, 73, 135, 235, 175, 48, 40, 137, 43, 89, 52, 179, 225, 27, 245, 165, 200, 144, 64, 70, 45, 151, 237, 100, 133, 237, 11, 13, 70, 6, 180, 126, 177, 107, 195, 47, 185, 148, 91, 204, 241, 43, 204, 125, 133, 173, 223, 37, 227, 33, 208, 54, 242, 168, 92, 77, 200, 4, 208, 112, 126, 86, 31, 104, 236, 7, 134, 62, 182, 4, 245, 206, 221, 110, 51, 0, 30, 161, 175, 234, 59, 85, 219, 131 }, "eleanor" },
                    { 3, "Whipholt", "Turkmenistan", new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1961, 8, 29), "female", "Quis cupidatat sunt culpa laboris deserunt aliqua deserunt ex incididunt eu laboris ex.", "Eiusmod cupidatat eu enim laboris mollit. Sit nostrud labore dolore dolore. Exercitation laboris nisi cillum est incididunt dolore elit minim et. Consequat qui culpa cillum nulla adipisicing exercitation ea nulla consequat sunt. Est tempor deserunt aute sint.\r\n", "Frances", new DateTime(2020, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ex nulla exercitation dolor aute tempor Lorem proident non nisi duis nulla labore sunt irure. Mollit sit excepteur laborum dolor mollit ad quis eiusmod elit laboris irure. Lorem laborum pariatur commodo laboris nisi pariatur nostrud deserunt. Occaecat proident nisi duis veniam officia tempor. Enim in eiusmod incididunt nulla veniam sit incididunt esse est minim do ipsum. Commodo incididunt fugiat culpa sunt deserunt eu aliquip amet duis esse. Culpa enim aliqua cupidatat eu minim irure esse sint eu deserunt.\r\n", new byte[] { 129, 103, 149, 78, 76, 97, 164, 251, 93, 123, 165, 135, 222, 65, 111, 48, 95, 85, 95, 168, 244, 38, 133, 236, 58, 100, 72, 99, 132, 171, 197, 68, 146, 41, 104, 139, 139, 220, 51, 133, 30, 188, 107, 88, 61, 75, 159, 31, 187, 51, 139, 254, 51, 165, 215, 97, 48, 67, 51, 104, 145, 28, 99, 155 }, new byte[] { 217, 191, 35, 50, 54, 125, 211, 0, 135, 70, 26, 223, 50, 238, 96, 185, 21, 23, 176, 43, 135, 106, 8, 13, 133, 106, 50, 114, 172, 197, 235, 210, 217, 253, 74, 136, 97, 82, 146, 52, 0, 151, 109, 159, 228, 101, 183, 178, 39, 152, 117, 164, 136, 228, 57, 24, 64, 3, 11, 11, 151, 221, 236, 171, 59, 228, 241, 160, 34, 98, 219, 114, 23, 151, 219, 89, 10, 94, 11, 130, 70, 107, 234, 52, 102, 21, 169, 177, 103, 125, 188, 125, 184, 42, 121, 224, 9, 126, 87, 152, 4, 29, 140, 147, 237, 247, 250, 50, 221, 157, 154, 135, 235, 207, 200, 85, 214, 7, 244, 125, 121, 94, 219, 244, 35, 45, 56, 216 }, "frances" },
                    { 4, "Gracey", "Norway", new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1972, 12, 17), "female", "Consectetur ullamco quis reprehenderit duis nostrud.", "Irure sunt eiusmod aute et laboris sunt magna. Dolore fugiat anim proident officia excepteur. Labore officia exercitation consequat do elit esse laborum laborum incididunt nisi sint duis commodo do. Exercitation ex officia Lorem est excepteur pariatur sunt cillum minim occaecat eu exercitation cillum.\r\n", "Lena", new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ea aliqua dolore exercitation duis qui ad nisi non deserunt voluptate. Consectetur consequat tempor pariatur elit consequat nostrud sunt. Laborum Lorem labore veniam do.\r\n", new byte[] { 25, 174, 64, 127, 204, 90, 82, 166, 127, 246, 211, 16, 241, 23, 98, 139, 59, 217, 126, 239, 180, 109, 160, 254, 9, 175, 87, 171, 173, 80, 58, 251, 215, 126, 247, 217, 117, 75, 8, 128, 234, 83, 249, 18, 37, 236, 81, 78, 173, 205, 156, 43, 233, 34, 71, 108, 214, 195, 155, 131, 181, 136, 204, 215 }, new byte[] { 233, 169, 27, 186, 68, 163, 75, 216, 221, 157, 196, 35, 77, 162, 218, 215, 79, 135, 196, 194, 105, 125, 25, 67, 83, 240, 175, 193, 107, 4, 208, 163, 74, 11, 252, 40, 70, 215, 43, 241, 46, 117, 69, 58, 25, 190, 19, 112, 57, 165, 146, 115, 17, 241, 152, 158, 188, 241, 217, 245, 41, 104, 113, 120, 106, 50, 193, 253, 75, 96, 69, 109, 98, 190, 179, 238, 194, 56, 108, 36, 199, 148, 26, 142, 125, 199, 156, 255, 52, 191, 106, 126, 51, 217, 181, 165, 134, 213, 34, 219, 206, 250, 183, 50, 245, 63, 243, 92, 46, 86, 103, 217, 49, 110, 142, 27, 236, 119, 53, 75, 11, 116, 86, 92, 175, 128, 236, 83 }, "lena" },
                    { 5, "Wilsonia", "Chile", new DateTime(2019, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1998, 7, 30), "female", "Velit enim culpa est Lorem consectetur fugiat.", "Aute fugiat aliquip nulla adipisicing Lorem. Mollit Lorem amet incididunt pariatur ex deserunt excepteur mollit nostrud Lorem laborum veniam magna ut. Velit adipisicing nostrud eu dolore esse labore. Sint incididunt et eiusmod laborum cillum non veniam cupidatat ad adipisicing mollit voluptate incididunt. Veniam elit ullamco sint tempor consequat cillum esse magna sunt consequat aliqua consectetur. Aliqua aliqua laboris culpa quis laboris esse.\r\n", "Nadine", new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et ea in dolor nostrud consectetur aute minim voluptate occaecat ex. Id est est laboris veniam aliqua duis et ullamco commodo mollit eu commodo occaecat. Labore ex amet aliquip nulla ullamco tempor magna mollit dolore dolore.\r\n", new byte[] { 218, 152, 44, 79, 143, 139, 208, 115, 130, 255, 88, 247, 81, 187, 227, 218, 68, 183, 28, 86, 192, 242, 80, 113, 71, 21, 18, 227, 139, 97, 248, 135, 18, 5, 175, 246, 6, 172, 28, 123, 13, 28, 22, 153, 143, 60, 126, 85, 50, 114, 103, 124, 121, 101, 170, 245, 155, 170, 64, 71, 130, 48, 251, 115 }, new byte[] { 185, 52, 246, 189, 142, 231, 95, 64, 74, 245, 47, 82, 144, 188, 12, 92, 134, 1, 57, 194, 43, 226, 168, 120, 238, 169, 224, 46, 111, 252, 14, 101, 116, 60, 253, 3, 207, 67, 210, 247, 145, 201, 72, 217, 36, 47, 14, 195, 14, 116, 238, 225, 238, 144, 82, 63, 191, 158, 247, 126, 63, 234, 186, 51, 159, 2, 193, 111, 105, 209, 194, 190, 0, 255, 250, 24, 28, 137, 226, 240, 42, 143, 200, 103, 7, 102, 248, 167, 60, 206, 141, 237, 79, 231, 59, 6, 99, 100, 128, 155, 140, 22, 208, 217, 119, 154, 242, 1, 27, 224, 230, 192, 18, 180, 234, 149, 134, 250, 105, 110, 44, 132, 50, 151, 90, 171, 136, 157 }, "nadine" },
                    { 6, "Roderfield", "Lesotho", new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1986, 5, 16), "male", "Do amet qui culpa labore.", "Anim adipisicing sunt elit id duis. Anim exercitation nulla sint sit irure proident id adipisicing magna magna fugiat qui minim ad. Id Lorem anim nulla excepteur excepteur eu duis mollit officia. Aute voluptate esse eiusmod deserunt deserunt amet culpa aute. Excepteur amet labore do adipisicing ut est mollit aliqua cupidatat eu nulla excepteur in. Proident cillum eiusmod esse incididunt et eu esse occaecat ullamco qui adipisicing qui minim. Eu nostrud excepteur et ipsum adipisicing est occaecat est.\r\n", "Ramos", new DateTime(2020, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nisi magna voluptate deserunt ad sit occaecat officia commodo ipsum sint cillum mollit exercitation. Consequat velit laborum qui anim adipisicing eiusmod dolor fugiat commodo elit. Ut sunt commodo officia proident non minim occaecat aute. Voluptate laborum ut ipsum reprehenderit. Consectetur ea non culpa non ipsum magna non reprehenderit esse ea ad. Officia elit aliquip velit ex tempor. Ut cupidatat duis laboris enim voluptate cillum tempor incididunt ut.\r\n", new byte[] { 123, 108, 217, 25, 195, 93, 109, 166, 103, 189, 4, 106, 5, 111, 189, 209, 157, 170, 43, 160, 243, 44, 33, 205, 135, 136, 162, 20, 182, 226, 252, 51, 95, 125, 200, 200, 76, 232, 107, 200, 122, 173, 139, 191, 210, 194, 254, 175, 104, 17, 50, 169, 93, 132, 185, 153, 176, 139, 117, 189, 73, 138, 113, 72 }, new byte[] { 138, 102, 73, 111, 219, 7, 44, 110, 238, 5, 41, 112, 194, 223, 130, 24, 168, 108, 195, 97, 116, 6, 123, 165, 73, 36, 212, 138, 230, 178, 243, 241, 217, 148, 96, 139, 159, 117, 72, 65, 201, 137, 211, 197, 137, 36, 83, 153, 98, 240, 110, 129, 89, 134, 180, 84, 73, 12, 81, 222, 133, 243, 33, 59, 27, 46, 5, 25, 50, 147, 149, 230, 45, 83, 134, 205, 202, 65, 5, 253, 5, 145, 158, 83, 58, 3, 42, 254, 106, 111, 75, 63, 164, 48, 92, 86, 47, 26, 82, 189, 156, 138, 3, 216, 199, 153, 95, 139, 29, 3, 158, 69, 242, 84, 106, 67, 10, 14, 235, 127, 190, 153, 134, 195, 35, 143, 214, 183 }, "ramos" },
                    { 7, "Boling", "Vatican City State (Holy See)", new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1983, 11, 26), "male", "Ex dolore est cupidatat veniam eu aliqua ad nulla nostrud.", "Laboris id aliquip in exercitation cillum excepteur incididunt amet excepteur consequat Lorem ut dolor. Dolor sint pariatur ex officia nostrud sint enim excepteur culpa proident. Tempor nostrud esse nisi enim quis velit enim culpa quis ex commodo deserunt minim id. In sit sunt irure laboris mollit consectetur ex dolore ullamco ea duis nisi nulla.\r\n", "Pratt", new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Incididunt ad ex incididunt magna. Proident reprehenderit enim ut et aliqua veniam sit excepteur aute tempor nisi. Esse minim id eiusmod pariatur amet ipsum aute consectetur dolore. Eiusmod et enim tempor sit aute aliquip anim. Incididunt anim incididunt ex culpa tempor culpa excepteur ut aliquip in.\r\n", new byte[] { 25, 20, 236, 80, 153, 4, 148, 210, 161, 93, 147, 157, 115, 38, 50, 235, 187, 63, 46, 194, 82, 49, 105, 116, 70, 63, 188, 99, 64, 209, 209, 88, 64, 80, 205, 234, 199, 109, 169, 99, 38, 63, 84, 103, 59, 142, 174, 170, 43, 201, 85, 197, 142, 182, 49, 100, 123, 226, 208, 198, 13, 201, 170, 62 }, new byte[] { 254, 22, 73, 33, 84, 199, 124, 205, 37, 159, 226, 66, 63, 36, 237, 81, 167, 203, 67, 217, 212, 33, 145, 253, 186, 163, 43, 116, 38, 105, 165, 235, 100, 85, 201, 234, 114, 107, 44, 15, 125, 102, 31, 61, 19, 183, 163, 249, 204, 57, 81, 244, 10, 127, 144, 170, 137, 210, 119, 247, 136, 126, 101, 90, 55, 8, 92, 252, 71, 125, 247, 188, 187, 231, 9, 148, 156, 183, 255, 150, 81, 65, 235, 13, 97, 50, 83, 16, 119, 160, 139, 202, 108, 112, 240, 245, 59, 123, 148, 185, 205, 23, 85, 253, 99, 78, 48, 20, 131, 21, 74, 250, 142, 52, 145, 128, 46, 143, 7, 163, 84, 114, 164, 101, 92, 208, 101, 79 }, "pratt" },
                    { 8, "Manila", "Gibraltar", new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1960, 3, 13), "male", "Ad esse mollit pariatur excepteur do officia amet.", "Pariatur nisi est et exercitation dolor consectetur quis veniam exercitation adipisicing laboris et cupidatat. Non enim aliquip aute aute duis dolore do sunt amet pariatur ea qui tempor eiusmod. Veniam excepteur nostrud culpa proident consectetur mollit. Laboris consequat magna incididunt in reprehenderit exercitation id magna culpa nisi.\r\n", "Powers", new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Id reprehenderit in anim dolore et enim do aliquip culpa. Qui incididunt culpa proident adipisicing laboris in Lorem eu. Nulla sint anim excepteur cupidatat. Ea culpa ea amet do sint. Do irure ad cillum aliquip quis eu velit proident nulla culpa sit officia nulla. Sunt irure ut magna nulla mollit. Ullamco ipsum aute ullamco in proident velit id ea.\r\n", new byte[] { 184, 166, 154, 55, 228, 104, 43, 248, 96, 172, 182, 230, 141, 195, 7, 185, 21, 109, 215, 227, 208, 94, 111, 65, 187, 160, 181, 35, 210, 188, 251, 79, 36, 100, 15, 32, 203, 49, 218, 246, 131, 245, 49, 162, 37, 236, 228, 154, 160, 242, 164, 45, 172, 109, 61, 22, 85, 127, 253, 191, 194, 40, 114, 224 }, new byte[] { 70, 197, 97, 232, 156, 4, 106, 243, 181, 109, 113, 166, 251, 234, 34, 173, 42, 250, 85, 90, 178, 224, 247, 57, 146, 95, 138, 217, 96, 20, 135, 212, 61, 199, 76, 192, 180, 229, 119, 254, 200, 61, 111, 172, 150, 4, 182, 192, 120, 105, 36, 199, 251, 26, 172, 194, 151, 173, 123, 243, 189, 102, 176, 26, 82, 107, 152, 147, 252, 65, 219, 55, 58, 234, 56, 147, 26, 195, 230, 161, 166, 42, 57, 87, 110, 70, 79, 146, 211, 45, 37, 234, 45, 69, 183, 3, 80, 71, 64, 124, 33, 192, 75, 95, 67, 95, 210, 62, 54, 214, 127, 16, 88, 27, 234, 13, 153, 239, 13, 97, 200, 241, 63, 179, 136, 119, 159, 78 }, "powers" },
                    { 9, "Beason", "Portugal", new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1955, 1, 21), "male", "Amet in voluptate anim aute cillum quis sunt non mollit non deserunt eiusmod consectetur exercitation.", "Elit non eiusmod deserunt enim veniam commodo labore dolore. Laborum mollit nisi do sit pariatur sunt eu amet fugiat nostrud mollit irure qui. Dolor deserunt esse ea cillum commodo magna dolor qui consectetur. Adipisicing elit officia amet ipsum tempor est nisi tempor velit sint pariatur irure fugiat. Esse amet laboris ipsum cillum eiusmod. Ad ea ea proident dolore commodo nisi ad laboris mollit esse tempor.\r\n", "Reeves", new DateTime(2020, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Occaecat laborum amet dolor exercitation magna. Sunt id sit ullamco sit consectetur officia. Dolore cupidatat ad Lorem ipsum eiusmod id ut dolor. Qui esse est enim dolor id eu laboris qui in et est deserunt. Id voluptate amet id irure nostrud esse officia occaecat incididunt magna velit ut. Lorem ex dolore eiusmod duis voluptate magna irure anim aute aute amet aute in irure.\r\n", new byte[] { 151, 77, 217, 233, 85, 158, 18, 52, 15, 140, 101, 76, 252, 89, 223, 26, 35, 125, 183, 15, 204, 119, 183, 223, 155, 96, 151, 44, 29, 127, 155, 194, 113, 224, 240, 0, 142, 152, 114, 250, 221, 183, 107, 218, 243, 245, 242, 215, 111, 100, 70, 37, 227, 99, 149, 98, 193, 132, 138, 20, 147, 85, 215, 215 }, new byte[] { 229, 69, 214, 181, 30, 87, 33, 161, 202, 183, 247, 236, 191, 217, 249, 83, 187, 177, 207, 173, 18, 59, 2, 60, 197, 108, 98, 233, 29, 154, 171, 34, 220, 123, 109, 196, 90, 78, 220, 240, 22, 208, 221, 74, 211, 173, 227, 48, 95, 154, 49, 191, 76, 49, 83, 161, 0, 237, 183, 206, 230, 26, 132, 52, 247, 239, 237, 65, 219, 233, 56, 226, 106, 254, 20, 56, 218, 36, 111, 255, 218, 42, 240, 231, 10, 20, 157, 211, 172, 165, 62, 225, 64, 0, 166, 41, 138, 13, 16, 99, 95, 87, 51, 183, 246, 175, 212, 177, 230, 182, 8, 65, 43, 234, 100, 80, 145, 251, 133, 182, 40, 208, 172, 188, 85, 32, 211, 133 }, "reeves" },
                    { 10, "Odessa", "Macau", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1970, 1, 29), "male", "Aliquip laborum do duis duis elit eu nisi irure irure proident.", "Enim adipisicing non in dolore nisi sunt quis et exercitation nulla nisi ullamco. Non nisi occaecat incididunt aliquip adipisicing ex ex. Elit amet veniam tempor non deserunt minim eiusmod deserunt laborum. Quis ad nostrud nostrud est. Consequat aliquip nostrud sit veniam. Quis occaecat id laborum occaecat occaecat sit officia sit reprehenderit veniam. Voluptate eu quis duis Lorem velit consequat non nulla duis.\r\n", "Kelly", new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adipisicing irure veniam ea sint consectetur tempor labore sunt laboris ea sunt. Ex esse commodo reprehenderit tempor duis cillum proident consequat est occaecat eu voluptate sit. Velit amet reprehenderit velit reprehenderit et ullamco quis anim magna eiusmod. Exercitation quis proident reprehenderit sit sunt fugiat nisi do dolor sunt elit cupidatat.\r\n", new byte[] { 193, 199, 71, 186, 101, 183, 69, 216, 24, 8, 239, 248, 213, 147, 254, 24, 172, 173, 136, 218, 253, 193, 166, 168, 169, 97, 234, 204, 147, 178, 66, 15, 82, 111, 183, 79, 81, 185, 120, 151, 97, 60, 143, 34, 67, 250, 217, 126, 56, 115, 68, 106, 118, 165, 201, 3, 226, 35, 243, 129, 121, 198, 112, 187 }, new byte[] { 208, 115, 57, 187, 77, 185, 176, 199, 123, 17, 111, 57, 39, 57, 176, 22, 2, 41, 24, 108, 57, 20, 247, 105, 185, 173, 228, 45, 142, 188, 32, 16, 196, 232, 81, 242, 173, 213, 92, 141, 21, 176, 115, 248, 77, 209, 78, 141, 149, 18, 95, 23, 135, 137, 202, 54, 4, 47, 238, 57, 45, 195, 23, 164, 253, 150, 4, 98, 41, 124, 203, 20, 189, 10, 249, 123, 52, 42, 54, 42, 70, 173, 122, 209, 157, 4, 64, 234, 96, 204, 147, 60, 77, 12, 101, 126, 18, 44, 168, 199, 79, 9, 234, 90, 155, 93, 218, 218, 253, 150, 37, 128, 220, 36, 157, 110, 172, 32, 61, 235, 27, 121, 117, 152, 155, 220, 93, 235 }, "kelly" }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "AppUserId", "IsMain", "PublicId", "Url" },
                values: new object[,]
                {
                    { 1, 1, true, null, "https://randomuser.me/api/portraits/women/78.jpg" },
                    { 2, 2, true, null, "https://randomuser.me/api/portraits/women/52.jpg" },
                    { 3, 3, true, null, "https://randomuser.me/api/portraits/women/82.jpg" },
                    { 4, 4, true, null, "https://randomuser.me/api/portraits/women/76.jpg" },
                    { 5, 5, true, null, "https://randomuser.me/api/portraits/women/30.jpg" },
                    { 6, 6, true, null, "https://randomuser.me/api/portraits/men/1.jpg" },
                    { 7, 7, true, null, "https://randomuser.me/api/portraits/men/48.jpg" },
                    { 8, 8, true, null, "https://randomuser.me/api/portraits/men/67.jpg" },
                    { 9, 9, true, null, "https://randomuser.me/api/portraits/men/79.jpg" },
                    { 10, 10, true, null, "https://randomuser.me/api/portraits/men/76.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
