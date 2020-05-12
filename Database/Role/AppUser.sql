CREATE ROLE [AppUser]
Go

GRANT EXECUTE On SCHEMA::[FilmApp] TO [AppUser];
Go

Alter Role [AppUser]
Add Member [GestFilm];
Go

