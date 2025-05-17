def log_message(message):
    print(f"[INFO] {message}")

def log_error(message):
    print(f"[ERROR] {message}")

def format_track_data(track):
    return {
        "title": track.get("name"),
        "artist": track.get("artists")[0].get("name") if track.get("artists") else "Unknown",
        "album": track.get("album").get("name") if track.get("album") else "Unknown",
        "release_date": track.get("album").get("release_date") if track.get("album") else "Unknown"
    }