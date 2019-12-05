DROP TABLE IF EXISTS produto_comprado;
DROP TABLE IF EXISTS nota;
DROP TABLE IF EXISTS produto;
DROP TABLE IF EXISTS cliente;

CREATE TABLE cliente (
	codigo SERIAL PRIMARY KEY,
	nome VARCHAR,
	cpf VARCHAR,
	endereco VARCHAR,
	bairro VARCHAR,
	cep VARCHAR,
	cidade VARCHAR,
	telefone VARCHAR,
	uf VARCHAR
);

CREATE TABLE produto (
	codigo SERIAL PRIMARY KEY,
	nome VARCHAR,
	valor INT,
	unidade VARCHAR
);

CREATE TABLE nota (
	codigo SERIAL PRIMARY KEY,
	cliente INT NOT NULL REFERENCES cliente(codigo),
	data TIMESTAMP
);

CREATE TABLE produto_comprado (
	nota INT NOT NULL REFERENCES nota(codigo) ON DELETE CASCADE,
	produto INT NOT NULL REFERENCES produto(codigo) ON DELETE CASCADE,
	quantidade INT
);

INSERT INTO cliente (codigo, nome, cpf,	endereco, bairro, cep, cidade, telefone, uf) VALUES
	(1, 'Angela Abar', '12345678910', 'Padaria', 'Centro', '9', 'Tulsa', '12', 'OK');

INSERT INTO produto (codigo, nome, valor, unidade) VALUES
	(1, 'DualShock 5', 20000, 'cx.'),
	(2, 'Agua', 10, 'ml'),
	(3, 'Redmi K32', 200000, 'un.');

INSERT INTO nota (codigo, cliente, data) VALUES
	(1, 1, current_timestamp);

INSERT INTO produto_comprado (nota, produto, quantidade) VALUES
	(1, 1, 2),
	(1, 2, 5000),
	(1, 3, 5);