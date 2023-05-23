<?php
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: DELETE");
header("Access-Control-Allow-Headers: Content-Type, Authorization");
require 'connect.php';

$id = $_GET['id'];
$sql = "DELETE FROM `recipe` WHERE `id` = '{$id}' LIMIT 1";

if (mysqli_query($con, $sql)) {
    http_response_code(204);
} else {
    http_response_code(422);
}
