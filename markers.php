<?php require("ignore/mysqlpass.php"); ?>

<markers>
<?php

	function format_date($d) {
		return date("g:ia M j 'y", strtotime($d));
	}

	/* take qsvars to use in query */
	$start = $_GET["start"] ? $_GET["start"] : gmdate("Y-m-d", time());
	$end = $_GET["end"] ? $_GET["end"] : gmdate("Y-m-d", time());

	$start_dt = "$start 00:00.000";
	$end_dt = "$end 23:59.000";

	$db = new mysqli("localhost", "root", $mysql_password, "4440");
	$query = "SELECT * FROM images WHERE (taken_at >= '$start_dt' AND taken_at <= '$end_dt') ORDER BY filename ASC";

	if ($result = $db->query($query)) {
		while($row = $result->fetch_assoc()) {
?>
			<marker lat="<?php echo $row['y']; ?>" lng="<?php echo $row['x']; ?>" 
				html="&lt;img src=&quot;images/demo/<?php echo $row['filename']; ?>&quot; width=&quot;200&quot; height=&quot;150&quot; /&gt;
					&lt;br&gt;&lt;b&gt;<?php echo $row['filename']; ?>&lt;/b&gt;
					&lt;br&gt;Taken at: <?php echo format_date($row['taken_at']); ?>"
				label="&lt;li&gt;<?php echo $row['filename']; ?>&lt;/li&gt;" />
<?php
		}
	}
?>

</markers> 
