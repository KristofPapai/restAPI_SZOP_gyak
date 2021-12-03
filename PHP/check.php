<?php

function checkLoggedIn($u, $p) {
	global $con;

	// Perform query
	$result = $con -> query("SELECT ID, Name, Password, Admin FROM users WHERE Name = '$u' AND Password = '$p'");

	return $result->fetch_all(MYSQLI_ASSOC)[0];
}

?>
