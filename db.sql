CREATE TABLE cliente (
    codigo SERIAL PRIMARY KEY,
    nome VARCHAR
);

CREATE TABLE produto (
    codigo SERIAL PRIMARY KEY,
    nome VARCHAR
);

CREATE TABLE nota (
    codigo SERIAL PRIMARY KEY,
    cliente INTEGER NOT NULL REFERENCES cliente(codigo)
);

CREATE TABLE produto_comprado (
    nota INTEGER NOT NULL REFERENCES nota(codigo),
    produto INTEGER NOT NULL REFERENCES produto(codigo),
    quantidade INTEGER
);