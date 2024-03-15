<script>
    let isMenuOpen = false;

    function toggleMenu() {
        isMenuOpen = !isMenuOpen;
    }
</script>

<style>
    @import '../../routes/global-styles.css';
    
    .top-nav {
        background-color: #4075a6;
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        color: white;
        z-index: 1000; /* Ensure it's on top of everything */
        padding: 10px 20px;
        display: flex;
        justify-content: space-between;
        align-items: center;
        height: var(--page-header-height)
    }

    .menu-icon {
        cursor: pointer;
    }

    .menu {
        position: absolute;
        top: 100%;
        right: 0;
        background-color: #333;
        color: white;
        z-index: 1001; /* Ensure it's on top of the header */
        padding: 10px;
    }

    .menu-item {
        padding: 5px 0;
        cursor: pointer;
    }

    .content {
        padding-right: 15px; /* Adjust this value to accommodate the scrollbar width */
    }
</style>

<div class="top-nav">
    <div>Logo/Title</div>
    <div class="menu-icon" on:click={toggleMenu}>
        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
        </svg>
    </div>
</div>

{#if isMenuOpen}
    <div class="menu">
        <div class="menu-item">Menu Item 1</div>
        <div class="menu-item">Menu Item 2</div>
        <div class="menu-item">Menu Item 3</div>
        <!-- Add more menu items as needed -->
    </div>
{/if}

<div class="content-container">
    <div class="content">
        <!-- Your page content goes here -->
        <!-- This content will be scrollable if it exceeds the height of the container -->
    </div>
</div>