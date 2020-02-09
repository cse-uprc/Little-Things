<?php
// Initialize the session
session_start();
 
// Check if the user is logged in, if not then redirect him to login page
if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true){
    header("location: login.php");
    exit;
}
else {
	 // initialize errors variable
	$host = 'nrb-term.mysql.database.azure.com';
	$db_username = 'nrbadmin@nrb-term';
	$password = 'M4W1srtA0l9';
	$db_name = 'term_proj';
	
// Create connection
	$conn = mysqli_init();
	mysqli_ssl_set($conn,NULL,NULL, "BaltimoreCyberTrustRoot.crt.pem", NULL, NULL) ; 
	mysqli_real_connect($conn, $host, $db_username, $password, $db_name, 3306, MYSQLI_CLIENT_SSL);
	if (mysqli_connect_errno($conn)) {
		die('Failed to connect to MySQL: '.mysqli_connect_error());
	}	

	// insert a quote if submit button is clicked
	if (isset($_POST['submit'])) {
		if (empty($_POST['habit'])) {
			$errors = "You must fill in the habit name field";
		}
		else if(empty($_POST['habit_t']))
		{
			$errors = "You must fill in the time duration field";
		}
		else if (empty($_POST['habit_f']))
		{
			$errors = "You must fill in the repetitions/day field";
		}
		else{
			$habit = $_POST['habit'];
			$habit_t = $_POST['habit_t'];
			$habit_f = $_POST['habit_f'];
			$user = $_SESSION["username"];
			$sql = "INSERT INTO habits (habitname,habittime,habitfreq,username) VALUES ('$habit',$habit_t,$habit_f,'$user')";
			echo $sql;
			mysqli_query($conn, $sql);
			header('location: welcome.php');
		}
	}	
	// delete task
if (isset($_GET['del_habit'])) {
	$id = $_GET['del_habit'];

	mysqli_query($conn, "DELETE FROM habits WHERE id=".$id);
	header('location: welcome.php');
}
}
?>
 
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Welcome</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.css">
	<link rel="stylesheet" type="text/css" href="style.css">
    <style type="text/css">
        body{ font: 14px sans-serif; text-align: center; }
    </style>
</head>
<body>
    <div class="page-header">
        <h1>Good day, <b><?php echo htmlspecialchars($_SESSION["username"]); ?></b>. Welcome to our site.</h1>
		<h2> We heard you like to say:  <em><?php echo htmlspecialchars($_SESSION["catchphrase"]); ?></em>.</h2>
    </div>
    <p>
        <a href="reset-password.php" class="btn btn-warning">Reset Your Password</a>
        <a href="logout.php" class="btn btn-danger">Sign Out of Your Account</a>
    </p>
		<div class="heading">
		<h2 style="font-style: 'Hervetica';">Habit-forming starts here</h2>
	</div>
	<form method="post" action="welcome.php" class="input_form">
		<?php if (isset($errors)) { ?>
		<p><?php echo $errors; ?></p>
		<?php } ?>
		Habit Name <input type="text" name="habit" class="habit_input"><br/>
		Time Duration <input type="number" name="habit_t" class="habit_input"> minutes
		<br/>
		Repetitions/day <input type="number" name="habit_f" class="habit_input">
		<button type="submit" name="submit" id="add_btn" class="add_btn">Add Habit</button>
	</form>
	<table>
	<thead>
		<tr>
			<th>N</th>
			<th>Habit</th>
			<th>Duration (minutes)</th>
			<th>Repetitions/day</th>
			<th style="width: 60px;">Action</th>
		</tr>
	</thead>

	<tbody>
		<?php 
		// select all tasks if page is visited or refreshed
		$user = $_SESSION["username"];
		$habits = mysqli_query($conn, "SELECT * FROM habits WHERE username='$user'");

		$i = 1; while ($row = mysqli_fetch_array($habits)) { ?>
			<tr>
				<td class="habit"> <?php echo $row['id']; ?> </td>
				<td class="habit"> <?php echo $row['habitname']; ?> </td>
				<td class="habit"> <?php echo $row['habittime']; ?> </td>
				<td class="habit"> <?php echo $row['habitfreq']; ?> </td>
				<td class="delete"> 
					<a href="welcome.php?del_habit=<?php echo $row['id'] ?>">x</a> 
				</td>
			</tr>
		<?php $i++; } ?>	
	</tbody>
</table>
	
	
</body>
</html>