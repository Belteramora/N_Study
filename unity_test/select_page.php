<?php

    include "connect.php";

    $themeName = $_GET["themeName"];
    $pageName = $_GET["pageName"];
    $acc_level = $_GET["acc_level"];

    $query = "SELECT `description` FROM `pages` WHERE `page_name` = '$pageName' AND `theme_name` = '$themeName' AND `access_level`=$acc_level";
    $result =  $database->query($query);

    echo $result->fetch_array()[0];

?>