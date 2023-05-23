<?php
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST");
header("Access-Control-Allow-Headers: Content-Type");
require 'connect.php';

$postdata = file_get_contents("php://input");
if (isset($postdata) && !empty($postdata)) {
    $request = json_decode($postdata);

    $name = mysqli_real_escape_string($con, trim($request->name));
    $author = mysqli_real_escape_string($con, trim($request->author));
    $type = mysqli_real_escape_string($con, trim($request->type));
    $actual_recipe = mysqli_real_escape_string($con, $request->actual_recipe);

    $sql = "INSERT INTO `recipe` (`name`, `author`, `type`, `actual_recipe`)
            VALUES ('{$name}', '{$author}', '{$type}', '{$actual_recipe}')
    ";
    if (mysqli_query($con, $sql)) {
        http_response_code(204);
    } else {
        http_response_code(422);
    }
}
