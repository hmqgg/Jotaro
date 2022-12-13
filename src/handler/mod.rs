use diesel::{prelude::*, r2d2::{ConnectionManager, Pool, PooledConnection}};
use serenity::{prelude::*, model::prelude::*, async_trait};

pub struct Handler {
    pool: Pool<ConnectionManager<SqliteConnection>>,
}

impl Handler {
    pub fn new(p: Pool<ConnectionManager<SqliteConnection>>) -> Self {
        Self { pool: p }
    }

    #[allow(dead_code)]
    fn conn(&self) -> PooledConnection<ConnectionManager<diesel::SqliteConnection>> {
        self.pool.get().unwrap()
    }
}

#[async_trait]
impl EventHandler for Handler {
    async fn ready(&self, _ctx: Context, ready: Ready) {
        println!("{} is connected!", ready.user.name);
    }
}
