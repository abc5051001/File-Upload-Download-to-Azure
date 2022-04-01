# File upload with ASP.NET Core Web API.
##### Table of Contents  
[Demo](#Demo)  
[Instructions](#Instructions)  
<a name="headers"/>
## Demo
<p> This code is intended to merge with ASP.NET web app which consists frontend and database to store the metadata as the following. </p>

![image](https://user-images.githubusercontent.com/82924798/161191032-db1815fc-d330-4497-b7d3-c6513450f553.png)

![Screenshot 2022-03-31 234328](https://user-images.githubusercontent.com/82924798/161191096-32b3b4ef-cdb4-45b4-9d6e-770b2ed8653b.png)

## Instructions
<b> In AppSetting change the ```"ConnectionString"``` and ```"ContainerName"``` to your Azure Storage Access Key and container name </b>
  <p> Next run the app and select file as the following demonstration </P>
  
![image](https://user-images.githubusercontent.com/82924798/161190584-d7092925-136b-42bb-90bb-ad3453b0f63c.png)

<P> Finally after uploaded the app will extract the metadata of the file and show on the post </P>

![image](https://user-images.githubusercontent.com/82924798/161190606-5f2b10c9-c3e8-4b3c-be99-0e510968d9dd.png)

