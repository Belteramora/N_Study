<?php

    include "connect.php";

    $themeName = $_GET["themeName"];
    $pageName = $_GET["pageName"];

    $query = "SELECT `description` FROM `pages` WHERE `page_name` = '$pageName' AND `theme_name` = '$themeName'";
    $result =  $db->query($query);

    echo $result->fetch_array()[0];

?>