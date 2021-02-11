<?php

    include "connect.php";

    $email= $_GET["email"];
    $password = $_GET["password"];

    $query = "SELECT * FROM `accounts` WHERE `email`='$email' AND `password`='$password'";
    $result = $database->query($query);


    if($result->num_rows > 0){
        echo "okey-".$result->fetch_array()[3];
    }
    else{
        echo "not_okey";
    }

?>