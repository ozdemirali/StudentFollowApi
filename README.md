# StudentFollowApi
This proje is created for the student information as Web Api and Mvc from Asp.Net in high school 

## Target framework
* .Net Framework 4.7.2

## Below are the frameworks used.
* EntityFramework v6.4.4
* ExelDataReader  v3.6.0
* ExelDataReader.DataSet v3.6.0
* Microsoft.Owin v4.2.0
* Microsoft.Owin.Host.SystemWeb v4.2.0
* Microsoft.Owin.Security v4.2.0
* Microsoft.Owin.Security.OAuth v4.2.0
* Newtonsoft.json v12.0.2

## Database
* Microsoft Sql Server is used.
* In Web.config file, The Data source shown as follows. 

# <connectionStrings>
    <add name="StudentFollowDbConnectionString" connectionString="Data Source=DESKTOP-B162HQA\SQLEXPRESS;Initial Catalog=StudentFollowDb;Integrated Security=true" 
         providerName="System.Data.SqlClient" />
 </connectionStrings>
 
 ### Controller
There are 7 controller
* FamilyController
* FamilyStudentController 
* FilterController
* GuardianController
* SiblingController
* StudentController
* StudentDetailController

### Authentication
* You must login first to use methods in this project. 
* You must get token for login. Token Role-Based Authentication is used.
* You can test on Postman as follows

* For Authentication
![Authentication](https://user-images.githubusercontent.com/20681737/158187616-7abc9dab-16e9-4a58-9d65-21ab2edbe33b.JPG)

### FamilyController
This controller have six method
* GetAllFamilies
 ![GetAllFamilies](https://user-images.githubusercontent.com/20681737/158187483-49fda2cf-d565-4c12-99ee-a809a9ee5952.JPG)

* GetFamilyById
 ![GetFamilyById](https://user-images.githubusercontent.com/20681737/158187492-ffd26abf-93e6-40c0-89b0-9ac6feb89beb.JPG)

* GetFamilyByStudentId
 ![GetFamilyByStudentId](https://user-images.githubusercontent.com/20681737/158187493-50b1a7c7-6a25-48e8-a428-4a94a425ef0d.JPG)

* PostNewFamily
 ![PostNewFamily_Header](https://user-images.githubusercontent.com/20681737/158187528-ca445193-bfe5-4713-88f9-7c38b12a4c3c.JPG)
 ![PostNewFamily_Body](https://user-images.githubusercontent.com/20681737/158187519-6dcdddde-0377-43a4-a2af-0d88b5120452.JPG)

* PutFamily
  ![PutFamily_Header](https://user-images.githubusercontent.com/20681737/158187566-10cf2e72-324c-4a88-bf16-2b967bc45107.JPG)
  ![PutFamily_Body](https://user-images.githubusercontent.com/20681737/158187563-4df1ce04-b5b8-4674-96ea-de19e2ba69b2.JPG)

* DeleteFamily
* 
### FamilyStudentController
![GetFamilyStudentById](https://user-images.githubusercontent.com/20681737/158187497-92568183-1656-4383-8574-e499b0952eb1.JPG)

### FilterController

### FamilyController

### GuardianController

### SiblingController

### StudentController

### StudentDetailController

![DeleteFamilyStudent](https://user-images.githubusercontent.com/20681737/158187468-462382f6-60eb-4366-84c6-b82f4b043150.JPG)
![DeleteGuardian](https://user-images.githubusercontent.com/20681737/158187473-acb96b55-5292-4b22-809a-67a8c6e83095.JPG)
![DeleteSibling](https://user-images.githubusercontent.com/20681737/158187476-98b3f3e7-c861-4094-94ce-8d28d21252cc.JPG)
![DeleteStudent](https://user-images.githubusercontent.com/20681737/158187478-6b1c13fd-66c0-4beb-9244-93486fd23ead.JPG)
![DeleteStudentDetail](https://user-images.githubusercontent.com/20681737/158187480-e86fb9cf-8637-4ad3-8bf4-589611b41117.JPG)

![GetAllGuardians](https://user-images.githubusercontent.com/20681737/158187486-91cf21bb-8b54-410b-90b3-c51dfaad207c.JPG)
![GetAllSiblings](https://user-images.githubusercontent.com/20681737/158187487-ecec141e-ad93-41d2-8bad-f36e6547b6f8.JPG)
![GetAllStudentDetails](https://user-images.githubusercontent.com/20681737/158187489-c35b018c-9e7b-4b8d-b16d-45c729b0bb3e.JPG)
![GetAllStudents](https://user-images.githubusercontent.com/20681737/158187491-66f500e9-e7e9-4a10-9408-99d14d891819.JPG)

![GetFilter](https://user-images.githubusercontent.com/20681737/158187500-3b38466c-a84c-4c13-ba3d-c9e8d67fb9e5.JPG)
![GetFilterData](https://user-images.githubusercontent.com/20681737/158187503-c0693a62-5bd0-47ca-9aec-68dec2cf6af0.JPG)
![GetGuardianById](https://user-images.githubusercontent.com/20681737/158187504-0ad0fbc7-3bc4-4e84-b2f2-ba3e03c6665d.JPG)
![GetSiblingById](https://user-images.githubusercontent.com/20681737/158187507-387e5e2a-a774-4326-9944-a95b314180e2.JPG)
![GetSiblingsByStudentId](https://user-images.githubusercontent.com/20681737/158187510-dad18093-c3ee-49cd-8c90-ff35cc97fc85.JPG)
![GetStudentById](https://user-images.githubusercontent.com/20681737/158187513-98cf6206-5f4c-4d65-8230-7f74d26bb1ac.JPG)
![GetStudentDeatailById](https://user-images.githubusercontent.com/20681737/158187516-d3ba5bdd-f6a6-468a-9eb9-f554df497e7e.JPG)

![PostNewFamilyStudent_Body](https://user-images.githubusercontent.com/20681737/158187531-aca51cec-e176-46d2-9e59-34b97e057b61.JPG)
![PostNewFamilyStudent_Header](https://user-images.githubusercontent.com/20681737/158187534-9fedf5f9-d162-410c-a613-67088f06a721.JPG)
![PostNewFilter_Body](https://user-images.githubusercontent.com/20681737/158187536-be8ea5b4-9808-4b01-8f74-428be9363fd6.JPG)
![PostNewFilter_Header](https://user-images.githubusercontent.com/20681737/158187540-ce7bf69c-8857-46d7-8323-3386fb00a529.JPG)
![PostNewGuardian_Body](https://user-images.githubusercontent.com/20681737/158187542-651088df-cda5-4e37-a68b-830c17e29947.JPG)
![PostNewGuardian_Header](https://user-images.githubusercontent.com/20681737/158187544-699a052a-3a56-4361-9d78-aa3ce2963211.JPG)
![PostNewSibling_Body](https://user-images.githubusercontent.com/20681737/158187546-6bc1bb28-d1d9-444e-a2bc-b97236e57241.JPG)
![PostNewSibling_Header](https://user-images.githubusercontent.com/20681737/158187549-3be55e03-b7f0-4420-b001-475da51d3c91.JPG)
![PostNewStudent_Body](https://user-images.githubusercontent.com/20681737/158187550-97e64154-0fcf-4dd9-8845-a5e5d9c21c76.JPG)
![PostNewStudent_Header](https://user-images.githubusercontent.com/20681737/158187553-4f695af7-b9a0-453e-9c67-2f0fd8b20ab4.JPG)
![PostNewStudentDetail_Body](https://user-images.githubusercontent.com/20681737/158187558-f8b9e277-efda-4015-939b-a316fe667618.JPG)
![PostNewStudentDetail_Header](https://user-images.githubusercontent.com/20681737/158187560-ba82963a-3235-45a2-a75d-96fcc7130562.JPG)

![PutFamilyStudent_Body](https://user-images.githubusercontent.com/20681737/158187570-7c08cd4e-09ea-4f24-bd98-fc7cf4be7595.JPG)
![PutFamilyStudent_Header](https://user-images.githubusercontent.com/20681737/158187573-300da34c-a543-4243-8867-6d7f8c95d745.JPG)
![PutGuradian_Body](https://user-images.githubusercontent.com/20681737/158187577-a68da589-0f4a-4c29-92b6-60db5f17120c.JPG)
![PutGuradian_Header](https://user-images.githubusercontent.com/20681737/158187581-e5f1c19c-97f5-4a48-82a2-7d8ff9077c40.JPG)
![PutSibling_Body](https://user-images.githubusercontent.com/20681737/158187582-cf2044a2-6374-49c9-b5c6-961e039d8f5b.JPG)
![PutSibling_Header](https://user-images.githubusercontent.com/20681737/158187586-224bea76-7ee6-4718-b04a-ef92e302f6d6.JPG)
![PutStudent_Body](https://user-images.githubusercontent.com/20681737/158187591-6b4e5296-54c1-400c-81fe-af02c04341cc.JPG)
![PutStudent_Header](https://user-images.githubusercontent.com/20681737/158187596-8c9831fc-be0d-4d15-ab04-c32ed9c7c19a.JPG)
![PutStudentDetail_Body](https://user-images.githubusercontent.com/20681737/158187603-f26359fa-19e3-4571-a6a4-5b7bf00c5021.JPG)
![PutStudentDetail_Header](https://user-images.githubusercontent.com/20681737/158187605-707c14c5-938f-4353-b85a-e7b0cba282ad.JPG)
![Upload_Body](https://user-images.githubusercontent.com/20681737/158187607-0a33652e-5ab2-48cf-a2d6-94cc1b8c65a9.JPG)
![Upload_Header](https://user-images.githubusercontent.com/20681737/158187610-d75ac24d-79e8-4597-ad0a-c97605f0d4e1.JPG)

