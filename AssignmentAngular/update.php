<?php
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET, POST, PUT, DELETE");
header("Access-Control-Allow-Headers: Content-Type, Authorization");

require 'connect.php';
$postdata = file_get_contents("php://input");
if (isset($postdata) && !empty($postdata)) {
    $request = json_decode($postdata);

    $id = mysqli_real_escape_string($con, (int)$_GET['id']);
    $name = mysqli_real_escape_string($con, trim($request->name));
    $author = mysqli_real_escape_string($con, trim($request->author));
    $type = mysqli_real_escape_string($con, trim($request->type));
    $actual_recipe = mysqli_real_escape_string($con, $request->actual_recipe);

    $sql = "UPDATE `recipe` SET `name`='$name', `author`='$author', `type`='$type', `actual_recipe`='$actual_recipe' WHERE `id`='$id' LIMIT 1";
        
    if (mysqli_query($con, $sql)) {
        http_response_code(204);
    } else {
        http_response_code(422);
    }
}

