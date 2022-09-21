USERNAME = 'postgress'
PASSWORD = 'banco123'
SERVER = 'localhost'
DB = 'gerenciamento_flask'

SQLALCHEMY_DATABASE_URI = f'postgres://{USERNAME}:{PASSWORD}@{SERVER}/{DB}'
SQLALCHEMY_TRACK_MODIFICATTIONS = True

SECRET_KEY = "minha-chave-secreta" 