<?php require("ignore/mysqlpass.php"); ?>
<?xml version="1.0" encoding="UTF-8"?>
<kml xmlns="http://earth.google.com/kml/2.2">
  <Document>
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
<Placemark>
	<name><?php echo $row['filename']; ?></name>
	<description>
        <![CDATA[
		Filename <?php echo $row['filename']; ?><br />
		Location: <?php echo $row['x']; ?>, <?php echo $row['y']; ?><br />
		Taken at: <?php echo $row['taken_at']; ?>
        ]]>
	</description>
	<Point>
		<coordinates><?php echo $row['x']; ?>,<?php echo $row['y']; ?>,0</coordinates>
	</Point>
</Placemark>
<?php
		}
	}
?>
  </Document>
</kml>
