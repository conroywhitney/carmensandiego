<?php

	$db = new mysqli("localhost", "root", "blackbag", "4440");
	if(mysqli_connect_errno()) {
		echo 'mysqli error';
	}

	$i = 0;
	for ($x = 0; $x <= 6000; $x += 3000) {
		for ($y = 0; $y <= 8000; $y += 4000) {
			$i++;

			$query = "INSERT INTO images(id, filename, x, y, taken_at, uploaded_at, updated_at) ";
			$query .= "VALUES('$i', 'file', '33.77".$x."', '-84.39".$y."', '2007-11-29 19:37:00.000', ";
			$query .= "'2007-11-29 19:37:00.000', '2007-11-29 19:37:00.000') ";
	
			echo "$query <br />";

			$db->query($query);
		}
	}

?>
