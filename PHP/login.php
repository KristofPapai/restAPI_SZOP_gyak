<?php

include("connection.php");
include("check.php");



$request = $_SERVER['REQUEST_METHOD'];

switch ($request) {
	case "GET":
		if (!empty($_GET["name"])) {
			$users = login($_GET["name"], $_GET["password"]);
		}
		else {
			$users = getUsers();
		}
		echo json_encode($users);
		break;
	case "POST":
		$content = file_get_contents('php://input');
		$data = json_decode($content);
		$user = checkLoggedIn($data["username"], $data["password"]);
		if (!$user or $user['isAdmin'] != '1') {
			header('HTTP/1.0 401 Unauthorized ');
			break;
		}
		$Addusername = $data["Addusername"];
		$Addpassword = $data["Addpassword"];
		$AddAdmin = $data["AddAdmin"];
		addUser($Addusername, $Addpassword,$AddAdmin);
		break;
	default:
		header('HTTP/1.1 405 Method Not Allowed');
		header('Allow: GET, POST, PUT, DELETE');
		break;
}

function login($u, $p) {
	global $con;
	$result = $con -> query("SELECT ID, Name, Password, Admin FROM users WHERE Name = '$u' AND Password = '$p'");
	return $result->fetch_all(MYSQLI_ASSOC)[0];
}

function getUsers(){
	global $con;
	$result = $con -> query("SELECT ID, Name, Password, Admin FROM users");
	return $result->fetch_all(MYSQLI_ASSOC);
}
function addUser($username, $password, $admin) {
	global $con;

	// Perform query
	$result = $con->query("INSERT INTO users (Name, Password, Admin) VALUES ('".$username."', '".$password."', '".$admin."')");
	echo json_encode($result);
}


?>
