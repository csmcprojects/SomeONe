<?php
//Auth token
$authToken = "l0kyOMiL8UZU2GIK";
$deviceName = "MySecretDevice";

//
if(isset($_GET["deviceName"]) && isset($_GET["deviceKey"]) && isset($_GET["deviceState"])){
	if($_GET["deviceKey"] == $authToken && $_GET["deviceName"] == $deviceName){
		SendDataToDB($_GET["deviceName"], $_GET["deviceState"]);
	}
} else {
	DisplayStatus();
}


//I'm supposing that there is already an entry in the database inserted manually via a database manager program like phpMyAdmin or
//a backoffice page, and so there is only the need to update the record, that i'm supposing that exists... This is not a good implementation
//for production code, this is just a simple and fast way to see things working.
//Also this code is adapted from w3school examples and it's not the way I would implement this, again this is just a fast way to see stuff.
function SendDataToDB($deviceName, $deviceStatus){
	$servername = "localhost";
	$username = "root";
	$password = "";
	$dbname = "myDB";
	// Create connection
	$conn = new mysqli($servername, $username, $password, $dbname);
	// Check connection
	if ($conn->connect_error) {
	    die("Connection failed: " . $conn->connect_error);
	} 

	$sql = "UPDATE someONe SET deviceStatus='".$deviceStatus."' WHERE deviceName='".$deviceName."'";

	if ($conn->query($sql) === TRUE) {
	    echo "Record created successfully";
	} else {
	    echo "Error: " . $sql . "<br>" . $conn->error;
	}

	$conn->close();
}

function GetStatus(){
	$servername = "localhost";
	$username = "root";
	$password = "";
	$dbname = "myDB";
	$deviceName = "MySecretDevice";

	// Create connection
	$conn = new mysqli($servername, $username, $password, $dbname);
	// Check connection
	if ($conn->connect_error) {
	    die("Connection failed: " . $conn->connect_error);
	} 

	//Supossing that the name is unique and forgetting all kinds of checks!
	$sql = "SELECT deviceStatus FROM someONe WHERE deviceName='".$deviceName."'";
	$result = $conn->query($sql);

	$row = $result->fetch_assoc();	        
	$conn->close();

	return $row["deviceStatus"];

}

function DisplayStatus(){
	$status = GetStatus();

	// Header of the page
	echo '<!doctype html><html><head></head>';

	if($status == "1"){
		echo '<body style="background-color:green;width:100%;height:100%;"><h1>Someone is in the room</h1>';
	} else {
		echo '<body style="background-color:red;width:100%;height:100%;"><h1>No one is in the room</h1>';
	}

	echo '</body></html>';
}

?>