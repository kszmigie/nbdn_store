("matt-richardson","houlgap","kszmigie","johnnycheng","DarrenRGuy","KevinBowdler","Butt3r5","toktuff","eblackburn","nathanbain") | foreach-object {
  git remote add $_ git://github.com/$_/nbdn_store.git
}
