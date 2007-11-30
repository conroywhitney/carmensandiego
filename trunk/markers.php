<?php require("mysqlpass.php"); ?>

<markers>
<?php
	/* take qsvars to use in query */
	$zoom = $_GET["zoom"]; $start = $_GET["start"]; $end = $_GET["end"];

	$db = new mysqli("localhost", "root", $mysql_password, "4440");
	$query = "SELECT * FROM images WHERE '1'"; 
	$result = $db->query($query);
?>

<?php while($row = $result->fetch_assoc()): ?>
	<marker lat="<?php echo $row['x']; ?>" lng="<?php echo $row['y']; ?>" 
		html="<?php echo "Displaying ".$row['x'].", ".$row['y'] ?>"  
		label="Marker (<?php echo $row['x'].", ".$row['y'] ?>)" />
<? endwhile; ?>

</markers> 
