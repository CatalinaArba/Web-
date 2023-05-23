<?php
require 'connect.php';

$id = $_GET['id'];

if (!isset($id) || empty($id)) {
    http_response_code(400);
    exit;
}

$sql = "SELECT * FROM `recipe` WHERE `id` = '{$id}' LIMIT 1";
$result = mysqli_query($con, $sql);
$row = mysqli_fetch_assoc($result);

echo json_encode($row);
exit;
?>
