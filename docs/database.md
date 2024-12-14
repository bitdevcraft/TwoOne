# Setting up PostgreSQL in Podman - Linux

This guide provides step-by-step instructions to set up a PostgreSQL instance using Podman.

---

## 1. Pull the PostgreSQL Image
Choose the PostgreSQL version you want and pull the image from a container registry (like Docker Hub).

```bash
podman pull docker.io/library/postgres:latest
```

Replace `15` with the desired version.

---

## 2. Create a Directory for Data Persistence
By default, data in a container is ephemeral. To persist PostgreSQL data, create a volume or a local directory.

```bash
mkdir -p ~/postgres-data
```

---

## 3. Run the PostgreSQL Container
Use the following command to run the PostgreSQL container:

```bash
podman run -d \
    --name postgres \
    -e POSTGRES_USER=admin \
    -e POSTGRES_PASSWORD=secret \
    -e POSTGRES_DB=twoone \
    -v ~/postgres-data:/var/lib/postgresql/data:Z \
    -p 5432:5432 \
    postgres:latest
```

- `POSTGRES_USER`: The username for the PostgreSQL database.
- `POSTGRES_PASSWORD`: The password for the PostgreSQL user.
- `POSTGRES_DB`: The default database to create.
- `~/postgres-data:/var/lib/postgresql/data:Z`: Maps your local directory for persistent storage. The `:Z` flag ensures proper SELinux labeling if SELinux is enabled.
- `-p 5432:5432`: Maps the container port 5432 (default PostgreSQL port) to the host.

---

## 4. Verify the Container is Running
Check the status of your container:

```bash
podman ps
```

---

## 5. Access the PostgreSQL Instance
You can access the PostgreSQL database using the `psql` command-line tool or a database client. To use `psql`:

1. Install the PostgreSQL client tools on your host machine.
2. Run:

```bash
psql -h localhost -U myuser -d mydatabase
```

You’ll be prompted to enter the password (`mypassword` in this case).

---

## 6. Manage the Container

- **Stop the container:**
  ```bash
  podman stop postgres
  ```

- **Start the container:**
  ```bash
  podman start postgres
  ```

- **Remove the container:**
  ```bash
  podman rm postgres
  ```

---

## 7. Optional: Create a Pod for Networking
If you want to group multiple containers, create a pod and run PostgreSQL inside it:

```bash
podman pod create --name mypod -p 5432:5432
podman run -d --pod mypod \
    --name postgres \
    -e POSTGRES_USER=myuser \
    -e POSTGRES_PASSWORD=mypassword \
    -e POSTGRES_DB=mydatabase \
    -v ~/postgres-data:/var/lib/postgresql/data:Z \
    postgres:15
```

This is helpful for deploying other services (like a backend application) alongside PostgreSQL in the same pod.

---

This setup provides a fully functional PostgreSQL database managed by Podman. Let me know if you encounter any issues!
