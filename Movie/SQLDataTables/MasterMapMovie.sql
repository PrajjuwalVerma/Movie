CREATE TABLE MasterMovie (
    MasterMapId int NOT NULL PRIMARY KEY,
    MovieId int  FOREIGN KEY REFERENCES MasterMovie(MovieId),
    ActorId int  FOREIGN KEY REFERENCES MasterActor(ActorId),
    ProducerId int  FOREIGN KEY REFERENCES MasterProducer(ProducerId)
);
