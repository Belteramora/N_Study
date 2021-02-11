<?php

    include "connect.php";

    $email= $_GET["email"];
    $password = $_GET["password"];
    $acc_level = $_GET["acc_level"];

    $query = "UPDATE `accounts` SET `email`='$email', `password`='$password', `current_acc_level`=$acc_level WHERE `email`='$email' AND `password`='$password'";
    $result = $database->query($query);

    echo $result;

?>