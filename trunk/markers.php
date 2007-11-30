<?php require("ignore/mysqlpass.php"); ?>

<markers>
<?php
	/* take qsvars to use in query */
	$start = $_GET["start"] ? $_GET["start"] : gmdate("Y-m-d", time());
	$end = $_GET["end"] ? $_GET["end"] : gmdate("Y-m-d", time());

	$start_dt = "$start 00:00.000";
	$end_dt = "$end 23:59.000";

	$db = new mysqli("localhost", "root", $mysql_password, "4440");
	$query = "SELECT * FROM images WHERE (taken_at >= '$start_dt' AND taken_at <= '$end_dt')";

	if ($result = $db->query($query)) {
		while($row = $result->fetch_assoc()) {
?>
			<marker lat="<?php echo $row['x']; ?>" lng="<?php echo $row['y']; ?>" 
				html="Filename <?php echo $row['filename']; ?>
					&lt;br&gt;Location: <?php echo $row['x']; ?>, <?php echo $row['y']; ?>
					&lt;br&gt;Taken at: <?php echo $row['taken_at']; ?>"
				label="<?php echo $row['filename']; ?>" />
<?
		}
	}
?>

</markers> 
