<?php

require 'connect.php';
error_reporting(E_ERROR);
$recipe=[];
$sql="SELECT * FROM recipe";
if($result =mysqli_query($con,$sql))
{
    $cr=0;
    while($row=mysqli_fetch_assoc($result))
    {
        $recipe[$cr]['id']=$row['id'];
        $recipe[$cr]['name']=$row['name'];
        $recipe[$cr]['author']=$row['author'];
        $recipe[$cr]['type']=$row['type'];
        $recipe[$cr]['actual_recipe']=$row['actual_recipe'];
        $cr++;
    }

    //print_r($recipe);
    echo json_encode($recipe);
}
else{
    http_response_code(404);
}
?>