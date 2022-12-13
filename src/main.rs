use diesel::{r2d2::{ConnectionManager, self}, SqliteConnection};
use diesel_migrations::{EmbeddedMigrations, embed_migrations, MigrationHarness};
use dotenvy::dotenv;
use jotaro::handler::Handler;
use serenity::{Client, prelude::*};
use std::env;

pub const MIGRATIONS: EmbeddedMigrations = embed_migrations!();

#[tokio::main]
async fn main() {
    dotenv().ok();

    let manager = ConnectionManager::<SqliteConnection>::new(
        env::var("DATABASE_URL").expect("Expected a database url in the environment"));
    let pool = r2d2::Pool::builder()
        .build(manager)
        .expect("Failed to create pool");
    let conn = &mut *pool.get().unwrap();
    conn.run_pending_migrations(MIGRATIONS).unwrap();

    let handler = Handler::new(pool);
    let token = env::var("DISCORD_TOKEN").expect("Expected a token in the environment");
    let mut client = Client::builder(&token, GatewayIntents::empty())
        .event_handler(handler)
        .await
        .expect("Error creating client");

    if let Err(why) = client.start().await {
        println!("Client error: {:?}", why);
    }
}
