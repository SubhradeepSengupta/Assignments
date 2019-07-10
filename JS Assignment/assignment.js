//Array for Qualification
var Qual = ["10th" , "12th", "Graduation"];
var qualification = "<option value="+"--Select-- "+"selected hidden>--Select--</option>";
var i;
//loop to print the array values in the select box
for(i=0; i<Qual.length; i++){
	qualification = qualification + "<option value="+Qual[i]+">"+Qual[i]+"</option>";
}
document.getElementById("qualificationid").innerHTML = qualification;


//Array for Experience
var Expr = ["1_Year" , "2_Year", "3_Year", "4_Year"];
var experience = "<option value="+"--Select-- "+"selected hidden>--Select--</option>";
var j;
//loop to print the array values in the select box
for(j=0; j<Qual.length; j++){
	experience = experience + "<option value="+Expr[j]+">"+Expr[j]+"</option>";
}
document.getElementById("experienceid").innerHTML = experience;

//Object constructor for coding language
function CodingLanguages(LanguageName, IsEnabled){
	this.LanguageName = LanguageName;
	this.IsEnabled = IsEnabled;
}

var first = new CodingLanguages("C/C++", false);
var second = new CodingLanguages("Java", true);
var third = new CodingLanguages("C#", true);
var fourth = new CodingLanguages("PHP", false);
var fifth = new CodingLanguages("Python", false);

//Adding names and check value to the checkboxes

var v = "<span id="+"l1"+"></span>";
v = v + "<span id="+"l1"+">"+first.LanguageName+"</span>"
document.getElementById("l1").innerHTML = v;
document.getElementById("language1").checked= first.IsEnabled;

var v = "<span id="+"l2"+"></span>";
v = v + "<span id="+"l2"+">"+second.LanguageName+"</span>"
document.getElementById("l2").innerHTML = v;
document.getElementById("language2").checked= second.IsEnabled;

var v = "<span id="+"l3"+"></span>";
v = v + "<span id="+"l3"+">"+third.LanguageName+"</span>"
document.getElementById("l3").innerHTML = v;
document.getElementById("language3").checked= third.IsEnabled;

var v = "<span id="+"l4"+"></span>";
v = v + "<span id="+"l4"+">"+fourth.LanguageName+"</span>"
document.getElementById("l4").innerHTML = v;
document.getElementById("language4").checked= fourth.IsEnabled;

var v = "<span id="+"l5"+"></span>";
v = v + "<span id="+"l5"+">"+fifth.LanguageName+"</span>"
document.getElementById("l5").innerHTML = v;
document.getElementById("language5").checked= fifth.IsEnabled;

var details = {
	FirstName : null,	
	LastName : null,
	Email : null,
	ContactNumber : null,
	Address : null,
	UserName : null,
	Password : null,
	Gender : null,
	Qualification : null,
	Experience : null,
	CodingLanguage : null
};

function putDetails(){
	details.FirstName = document.getElementById("userfirstname").value;
	details.LastName = document.getElementById("userlastname").value;
	details.Email = document.getElementById("usermail").value;
	details.ContactNumber = document.getElementById("usertelephone").value;
	details.Address = document.getElementById("useraddress").value;
	details.UserName = document.getElementById("username").value;
	details.Password = document.getElementById("userpassword").value;
	details.Gender = document.getElementsByName("gender");
	if(details.Gender[0].checked)
	{
		details.Gender = "Male";
	}
	else
	{
		details.Gender = "Female";
	}
	details.Qualification = document.getElementById("qualificationid").value;
	details.Experience = document.getElementById("experienceid").value;
	details.CodingLanguage = document.getElementsByName("lang");
	var code = "";
	for(i=0; i<details.CodingLanguage.length; i++){
		if(details.CodingLanguage[i].checked === true)
		{
			code = code + details.CodingLanguage[i].value+ " ";		
		}
	}
	details.CodingLanguage = code;
	
	console.log(details);
	/*alert(details.FirstName);
	alert(details.LastName);
	alert(details.Email);
	alert(details.ContactNumber);
	alert(details.Address);
	alert(details.UserName);
	alert(details.Password);
	alert(details.Gender);
	alert(details.Qualification);
	alert(details.Experience);
	alert(details.CodingLanguage);*/
}




