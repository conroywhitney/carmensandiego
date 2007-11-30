<?php require("ignore/mysqlpass.php"); ?>

<?php
	/* Set defaults in case of some weird mixup with DB */
	$min_date = gmdate("Y-m-d", time());
	$max_date = gmdate("Y-m-d", time());
	$num_dates = 0;
	$values_count_js = "[]";
	$dates_js = "[]";

	/* create MySQLi obj */
	$db = new mysqli("localhost", "root", $mysql_password, "4440");

	$query = "SELECT MIN(taken_at) AS min_dt, MAX(taken_at) AS max_dt, COUNT(DISTINCT taken_at) AS num_dates FROM images";
	if ($result = $db->query($query)) {
		if ($row = $result->fetch_assoc()) {
			$min_dt = $row['min_dt'];
			$max_dt = $row['max_dt'];
			$num_dates = $row['num_dates'];
			
			$values_count = array();
			for ($i = 0; $i < $num_dates; $i++) {
				array_push($values_count, $i);
			}
			$values_count_js = "[".implode(",", $values_count)."]";

			/* convert to date */
			$min_date = date("Y-m-d", strtotime($min_dt));
			$max_date = date("Y-m-d", strtotime($max_dt));
		}
	}

	$query = "SELECT DISTINCT taken_at AS date FROM images ORDER BY taken_at ASC";
	$date_arr = array();
	if ($result = $db->query($query)) {
		if ($result->num_rows > 0) {
			while ($row = $result->fetch_assoc()) {
				array_push($date_arr, date("Y-m-d", strtotime($row['date'])));
			}
			$dates_js = "['".implode("','", $date_arr)."']";
		}		
	}
?>
